import { inject, Injectable } from '@angular/core';
import { Order } from '../../../business/domain/entities/order.entity';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { AuthService } from '../../../core/services/auth.service';
import { ConfigService } from '../../../core/services/config.service';
import { catchError, firstValueFrom, throwError } from 'rxjs';
import { OrderResponse } from './dtos/order.response';
import { agentsMapper } from '../agents.mapper';

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

  public async getOrders(): Promise<Order[]> {
    const url = `${this.ordersUrl}`;
    const headers = new HttpHeaders().set('Authorization', `Bearer ${this.authService.appUserAuth.access_token}`);

    const response = await firstValueFrom(this.http.get<OrderResponse[]>(url, { headers }).pipe(catchError(this.handleError)));
    const orders = agentsMapper.mapArray(response, OrderResponse, Order);
    return orders;
  }

  public async getOrdersByOrderId(orderId: string): Promise<Order> {
    const url = `${this.ordersUrl}/${orderId}`;
    const headers = new HttpHeaders().set('Authorization', `Bearer ${this.authService.appUserAuth.access_token}`);

    const response = await firstValueFrom(this.http.get<OrderResponse>(url, { headers }).pipe(catchError(this.handleError)));
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
}
