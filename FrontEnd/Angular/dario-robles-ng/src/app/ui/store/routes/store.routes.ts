import { Routes } from '@angular/router';
import { ItemListComponent } from '../items/components/item-list/item-list.component';
import { StoreShellComponent } from '../shell/layout/store-shell.component';
import { authGuard } from '../../../core/guards/auth.guard';

export const STORE_ROUTES: Routes = [
  {
    path: '', component: StoreShellComponent, canActivate: [authGuard],
    children: [
      { path: '', redirectTo: 'orders', pathMatch: 'full'},
      { path: 'orders', loadChildren: () => import('../orders/routes/orders.routes').then(m => m.ORDERS_ROUTES) },
      { path: 'items', component: ItemListComponent }
    ]
  }
];
