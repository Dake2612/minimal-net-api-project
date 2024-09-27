import { Routes } from '@angular/router';
import { OrderListPageComponent } from '../orders/pages/order-list-page/order-list-page.component';
import { OrderDetailPageComponent } from '../orders/pages/order-detail-page/order-detail-page.component';
import { OrderEditPageComponent } from '../orders/pages/order-edit-page/order-edit-page.component';
import { OrderEditInfoComponent } from '../orders/components/order-edit-info/order-edit-info.component';
import { ItemListComponent } from '../items/components/item-list/item-list.component';
import { OrderDetailResolver } from './resolvers/order-detail.resolver';
import { OrderEditResolver } from './resolvers/order-edit.resolver';
import { StoreShellComponent } from '../shell/layout/store-shell.component';
import { authGuard } from '../../../core/guards/auth.guard';
import { OrdersResolver } from './resolvers/order.resolver';

export const STORE_ROUTES: Routes = [
  {
    path: '', component: StoreShellComponent, canActivate: [authGuard],
    children: [
      { path: '', redirectTo: 'orders', pathMatch: 'full'},
      { path: 'orders', component: OrderListPageComponent, data: { pageTitle: 'Orders' }, resolve: { orders: OrdersResolver } },
      { path: 'orders/new', component: OrderEditPageComponent, },
      { path: 'orders/:orderId', component: OrderDetailPageComponent, resolve: { order: OrderDetailResolver } },
      { path: 'orders/:orderId/edit', component: OrderEditPageComponent, resolve: { order: OrderEditResolver },
        children: [
          { path: '', redirectTo: 'info', pathMatch: 'full' },
          { path: 'info', component: OrderEditInfoComponent },
          { path: 'items', component: ItemListComponent }
        ]
      },
    ]
  }
];
