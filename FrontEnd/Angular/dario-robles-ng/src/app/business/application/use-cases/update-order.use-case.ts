import { inject, Injectable } from "@angular/core";
import { ORDER_REPOSITORY_TOKEN } from "../../domain/repositories/repository.tokens";
import { OrderModel } from "../models/orders/order.model";
import { applicationMapper } from "../mappers/application.mapper";
import { Order } from "../../domain/entities/order.entity";

@Injectable({
  providedIn: 'root'
})

export class UpdateOrderUseCase {
  private orderRepository = inject(ORDER_REPOSITORY_TOKEN);

  public async execute(orderId: string, order: OrderModel): Promise<OrderModel> {
    const orderEntity = applicationMapper.map(order, OrderModel, Order);
    const updatedOrderEntity = await this.orderRepository.updateOrder(orderId, orderEntity);
    const updatedOrderModel = applicationMapper.map(updatedOrderEntity, Order, OrderModel);
    return updatedOrderModel;
  }
}
