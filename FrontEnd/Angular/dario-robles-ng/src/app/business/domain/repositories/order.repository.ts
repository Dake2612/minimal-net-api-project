import { PaginatedResult } from "../../../infraestructure/agents/orders/dtos/paginated-result";
import { Order } from "../entities/order.entity";

export interface OrderRepository {
  getOrders(state: string | null, searchQuery: string | null, orderBy: string, sortDirection: string, pageNumber: number, pageSize: number): Promise<PaginatedResult<Order>>;
  getOrderById(orderId: string): Promise<Order>;
  getStates(): Promise<Array<string>>;
  updateOrder(orderId: string, order: Order): Promise<Order>;
  createOrder(order: Order): Promise<Order>;
  deleteOrder(orderId: string): Promise<void>;
}
