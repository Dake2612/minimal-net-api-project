import { inject, Injectable } from "@angular/core";
import { OrderRepository } from "../../business/domain/repositories/order.repository";
import { Order } from "../../business/domain/entities/order.entity";
import { OrdersAgent } from "../agents/orders/orders.agent";
import { PaginatedResult } from "../agents/orders/dtos/paginated-result";

@Injectable({
  providedIn: 'root'
})

export class OrderRepositoryImpl implements OrderRepository{
  private orderAgent = inject(OrdersAgent);

  public async getOrderById(orderId: string): Promise<Order> {
    return await this.orderAgent.getOrdersByOrderId(orderId);
  }

  public getOrders(state: string | null, searchQuery: string | null, orderBy: string, sortDirection: string, pageNumber: number, pageSize: number): Promise<PaginatedResult<Order>> {
    return this.orderAgent.getOrders(state, searchQuery, orderBy, sortDirection, pageNumber, pageSize);
  }

  public async updateOrder(orderId: string, order: Order): Promise<Order> {
    return await this.orderAgent.updateOrder(orderId, order);
  }

  public async createOrder(order: Order): Promise<Order> {
    return await this.orderAgent.createOrder(order);
  }

  public async deleteOrder(orderId: string): Promise<void> {
    return await this.orderAgent.deleteOrder(orderId);
  }

  public getStates(): Promise<Array<string>> {
    return this.orderAgent.getStates();
  }
}
