import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { GetOrderByOrderIdUseCase } from '../../../../business/application/use-cases/get-order-by-order-id.use-case';
import { OrderModel } from '../../../../business/application/models/orders/order.model';

export const OrderDetailResolver: ResolveFn<OrderModel> = (route, state) => {
  const getOrderByOrderIdUseCase = inject(GetOrderByOrderIdUseCase);
  const orderId = route.paramMap.get('orderId');

  const order = getOrderByOrderIdUseCase.execute(orderId!);
  return order;
};
