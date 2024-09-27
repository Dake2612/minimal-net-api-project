import { Provider } from "@angular/core";
import { ORDER_REPOSITORY_TOKEN } from "../../business/domain/repositories/repository.tokens";
import { OrderRepositoryImpl } from "../persistence/order.repository.impl";

export function provideRepositories(): Provider[] {
  return [
    { provide: ORDER_REPOSITORY_TOKEN, useClass: OrderRepositoryImpl },
  ]
}
