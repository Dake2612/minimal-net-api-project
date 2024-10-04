import { classes } from "@automapper/classes";
import { createMap, createMapper, Mapper } from "@automapper/core";
import { OrderResponse } from "./orders/dtos/order.response";
import { Order } from "../../business/domain/entities/order.entity";
import { OrderForUpdateRequest } from "./orders/dtos/order-for-update.request";
import { OrderForCreationRequest } from "./orders/dtos/order-for-creation.request";

export const agentsMapper: Mapper = createMapper({
  strategyInitializer: classes(),
});

createMap(agentsMapper, OrderResponse, Order);
createMap(agentsMapper, Order, OrderForUpdateRequest);
createMap(agentsMapper, Order, OrderForCreationRequest);
