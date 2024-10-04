import { Routes } from "@angular/router";
import { OrdersShellComponent } from "../shell/layout/orders-shell.component";
import { OrderListPageComponent } from "../pages/order-list-page/order-list-page.component";
import { OrderEditPageComponent } from "../pages/order-edit-page/order-edit-page.component";
import { OrderDetailPageComponent } from "../pages/order-detail-page/order-detail-page.component";
import { OrderDetailResolver } from "./resolvers/order-detail.resolver";
import { OrderEditResolver } from "./resolvers/order-edit.resolver";
import { OrderEditInfoComponent } from "../components/order-edit-info/order-edit-info.component";
import { ItemListComponent } from "../../items/components/item-list/item-list.component";
import { OrdersResolver } from "./resolvers/order.resolver";

export const ORDERS_ROUTES: Routes = [
  {
    path: '', component: OrdersShellComponent,
    children: [
      {
        path: '', component: OrderListPageComponent
        //, resolve: { orders: OrdersResolver }
      },
      { path: 'new', component: OrderEditPageComponent, },
      { path: ':orderId', component: OrderDetailPageComponent, resolve: { order: OrderDetailResolver } },
      { path: ':orderId/edit', component: OrderEditPageComponent, resolve: { order: OrderEditResolver } },
    ]
  }
]
