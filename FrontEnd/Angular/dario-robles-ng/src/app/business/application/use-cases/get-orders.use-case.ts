import { inject, Injectable } from "@angular/core";
import { ORDER_REPOSITORY_TOKEN } from "../../domain/repositories/repository.tokens";
import { OrderModel } from "../models/orders/order.model";
import { Order } from "../../domain/entities/order.entity";
import { applicationMapper } from "../mappers/application.mapper";

@Injectable({
  providedIn: 'root'
})

export class GetOrdersUseCase {
  private orderRespository = inject(ORDER_REPOSITORY_TOKEN);

  public async execute(): Promise<OrderModel[]> {
    const orders = await this.orderRespository.getOrders();
    return applicationMapper.mapArray(orders, Order, OrderModel);
  }
}
