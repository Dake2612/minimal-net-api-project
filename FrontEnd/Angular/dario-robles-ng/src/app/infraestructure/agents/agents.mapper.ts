import { classes } from "@automapper/classes";
import { createMap, createMapper, Mapper } from "@automapper/core";
import { OrderResponse } from "./orders/dtos/order.response";
import { Order } from "../../business/domain/entities/order.entity";

export const agentsMapper: Mapper = createMapper({
  strategyInitializer: classes(),
});

createMap(agentsMapper, OrderResponse, Order);
