import { InjectionToken } from "@angular/core";
import { OrderRepository } from "./order.repository";

export const ORDER_REPOSITORY_TOKEN = new InjectionToken<OrderRepository>('OrderRepository');
