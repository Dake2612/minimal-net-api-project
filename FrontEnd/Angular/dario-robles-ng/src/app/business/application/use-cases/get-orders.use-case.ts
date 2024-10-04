import { inject, Injectable } from "@angular/core";
import { ORDER_REPOSITORY_TOKEN } from "../../domain/repositories/repository.tokens";
import { OrderModel } from "../models/orders/order.model";
import { Order } from "../../domain/entities/order.entity";
import { applicationMapper } from "../mappers/application.mapper";
import { PaginatedResult } from "../../../infraestructure/agents/orders/dtos/paginated-result";

@Injectable({
  providedIn: 'root'
})

export class GetOrdersUseCase {
  private orderRespository = inject(ORDER_REPOSITORY_TOKEN);

  public async execute(state: string | null = null, searchQuery: string | null = null, orderBy: string = '', sortDirection: string = '', pageNumber: number = 0, pageSize: number = 10): Promise<PaginatedResult<OrderModel>> {
    const paginatedOrders = await this.orderRespository.getOrders(state, searchQuery, orderBy, sortDirection, pageNumber, pageSize);
    const orders = applicationMapper.mapArray(paginatedOrders.data, Order, OrderModel);
    const result: PaginatedResult<OrderModel> = {
      data: orders,
      pagination: paginatedOrders.pagination
    };
    return result;
  }
}
