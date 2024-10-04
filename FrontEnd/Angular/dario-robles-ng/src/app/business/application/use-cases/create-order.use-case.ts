import { inject, Injectable } from "@angular/core";
import { ORDER_REPOSITORY_TOKEN } from "../../domain/repositories/repository.tokens";
import { OrderModel } from "../models/orders/order.model";
import { applicationMapper } from "../mappers/application.mapper";
import { Order } from "../../domain/entities/order.entity";

@Injectable({
  providedIn: 'root'
})

export class CreateOrderUseCase {
  private orderRepository = inject(ORDER_REPOSITORY_TOKEN);

  public async execute(order: OrderModel): Promise<OrderModel> {
    const orderEntity = applicationMapper.map(order, OrderModel, Order);
    const createdOrderEntity = await this.orderRepository.createOrder(orderEntity);
    const createdOrderModel = applicationMapper.map(createdOrderEntity, Order, OrderModel);
    return createdOrderModel;
  }
}
