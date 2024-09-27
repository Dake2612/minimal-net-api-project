import { Order } from "../entities/order.entity";

export interface OrderRepository {
  getOrders(): Promise<Order[]>;
  getOrderById(orderId: string): Promise<Order>;
}
