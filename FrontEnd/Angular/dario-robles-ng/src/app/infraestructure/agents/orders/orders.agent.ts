import { inject, Injectable } from '@angular/core';
import { Order } from '../../../business/domain/entities/order.entity';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { AuthService } from '../../../core/services/auth.service';
import { ConfigService } from '../../../core/services/config.service';
import { catchError, delay, firstValueFrom, throwError } from 'rxjs';
import { OrderResponse } from './dtos/order.response';
import { agentsMapper } from '../agents.mapper';
import { PaginatedResult } from './dtos/paginated-result';
import { OrderForUpdateRequest } from './dtos/order-for-update.request';
import { OrderForCreationRequest } from './dtos/order-for-creation.request';

@Injectable({
  providedIn: 'root'
})
export class OrdersAgent {
  private ordersUrl = '';
  private http = inject(HttpClient);
  private authService = inject(AuthService);
  private configService = inject(ConfigService);

  constructor() {
    this.ordersUrl = `${this.configService.getValue('ORDERS_URL')}`;
  }

  public async getOrders(
    state: string | null,
    searchQuery: string | null,
    orderBy: string,
    sortDirection: string,
    pageNumber: number,
    pageSize: number
  ): Promise<PaginatedResult<Order>> {
    let url = `${this.ordersUrl}?pageNumber=${pageNumber + 1}&pageSize=${pageSize}&OrderBy=${orderBy} ${sortDirection}`;
    if (searchQuery) {
      url = `${url}&searchQuery=${searchQuery}`;
    }
    if (state) {
      url = `${url}&State=${state}`;
    }
    const response = await firstValueFrom(this.http.get<OrderResponse[]>(url, { observe: 'response'}).pipe(
      delay(1000),
      catchError(this.handleError)
    ));
    const paginationHeader = response.headers.get('X-Pagination');
    const paginationData = paginationHeader ? JSON.parse(paginationHeader) : null;
    const orders = agentsMapper.mapArray(response.body || [], OrderResponse, Order);
    const result: PaginatedResult<Order> = {
      data: orders,
      pagination: paginationData
    };
    return result;
  }

  public getStates(): Promise<Array<string>> {
    const states: string[] = [
      'ready_to_deliver',
      'delivered',
      'registered'
    ];
    return Promise.resolve(states);
  }

  public async getOrdersByOrderId(orderId: string): Promise<Order> {
    const url = `${this.ordersUrl}/${orderId}`;
    const response = await firstValueFrom(this.http.get<OrderResponse>(url).pipe(catchError(this.handleError)));
    const order = agentsMapper.map(response, OrderResponse, Order);
    return order;
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error: ', error);
    if (error.error instanceof Error) {
      const errMessage = error.error.message;
      return throwError(() => errMessage);
    }
    return throwError(() => error || 'Server error');
  }

  public async updateOrder(orderId: string, order: Order): Promise<Order> {
    const url = `${this.ordersUrl}/${orderId}`;
    const orderForUpdateRequest = agentsMapper.map(order, Order, OrderForUpdateRequest);
    const response = await firstValueFrom(this.http.put<OrderResponse>(url, orderForUpdateRequest).pipe(catchError(this.handleError)));
    const updatedOrder = agentsMapper.map(response, OrderResponse, Order);
    return updatedOrder;
  }

  public async createOrder(order: Order): Promise<Order> {
    const url = `${this.ordersUrl}`;
    const orderForCreationRequest = agentsMapper.map(order, Order, OrderForCreationRequest);
    const response = await firstValueFrom(this.http.post<OrderResponse>(url, orderForCreationRequest).pipe(catchError(this.handleError)));
    const CreatedOrder = agentsMapper.map(response, OrderResponse, Order);
    return CreatedOrder;
  }

  public async deleteOrder(orderId: string): Promise<void> {
    const url = `${this.ordersUrl}/${orderId}`;
    await firstValueFrom(this.http.delete(url).pipe(catchError(this.handleError)));
  }
}
