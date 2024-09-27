import { createMap, createMapper, Mapper } from '@automapper/core';
import { classes } from '@automapper/classes';
import { Order } from '../../domain/entities/order.entity';
import { OrderModel } from '../models/orders/order.model';

export const applicationMapper: Mapper = createMapper({
  strategyInitializer: classes()
})

createMap(applicationMapper, Order, OrderModel);
