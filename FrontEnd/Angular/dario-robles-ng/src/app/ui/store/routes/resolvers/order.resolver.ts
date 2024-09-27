import { ResolveFn } from "@angular/router";
import { OrderModel } from "../../../../business/application/models/orders/order.model";
import { inject } from "@angular/core";
import { GetOrdersUseCase } from "../../../../business/application/use-cases/get-orders.use-case";

export const OrdersResolver: ResolveFn<Promise<OrderModel[]>> = (route, state) => {
  const getOrdersUseCase = inject(GetOrdersUseCase);

  const orders = getOrdersUseCase.execute();

  return orders;
}
