import { inject, Injectable } from "@angular/core";
import { ORDER_REPOSITORY_TOKEN } from "../../domain/repositories/repository.tokens";
import { OrderModel } from "../models/orders/order.model";
import { applicationMapper } from "../mappers/application.mapper";
import { Order } from "../../domain/entities/order.entity";

@Injectable({
  providedIn: 'root'
})

export class DeleteOrderUseCase {
  private orderRepository = inject(ORDER_REPOSITORY_TOKEN);

  public async execute(orderId: string): Promise<void> {
    await this.orderRepository.deleteOrder(orderId);
  }
}
