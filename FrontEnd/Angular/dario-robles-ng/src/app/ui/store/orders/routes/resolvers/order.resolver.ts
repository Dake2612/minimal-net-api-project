import { ResolveFn } from "@angular/router";
import { inject } from "@angular/core";
import { GetOrdersUseCase } from "../../../../../business/application/use-cases/get-orders.use-case";
import { LoadingService } from "../../../../shared/components/loading/services/loading.service";
import { OrderModel } from "../../../../../business/application/models/orders/order.model";
import { PaginatedResult } from "../../../../../infraestructure/agents/orders/dtos/paginated-result";

export const OrdersResolver: ResolveFn<Promise<PaginatedResult<OrderModel>>> = async (route, state) => {
  const getOrdersUseCase = inject(GetOrdersUseCase);
  const loadingService = inject(LoadingService);

  loadingService.show();

  try {
    const orders = await getOrdersUseCase.execute();
    return orders;
  } finally {
    loadingService.hide();
  }
}
