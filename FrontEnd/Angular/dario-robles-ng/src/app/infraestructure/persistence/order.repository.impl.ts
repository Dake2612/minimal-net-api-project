import { inject, Injectable } from "@angular/core";
import { OrderRepository } from "../../business/domain/repositories/order.repository";
import { Order } from "../../business/domain/entities/order.entity";
import { OrdersAgent } from "../agents/orders/orders.agent";

@Injectable({
  providedIn: 'root'
})

export class OrderRepositoryImpl implements OrderRepository{
  private orderAgent = inject(OrdersAgent);

  public async getOrderById(orderId: string): Promise<Order> {
    return await this.orderAgent.getOrdersByOrderId(orderId);
  }

  public async getOrders(): Promise<Order[]> {
    return await this.orderAgent.getOrders();
  }
}
