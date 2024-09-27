import { Routes } from '@angular/router';
import { HomePageComponent } from '../pages/home-page/home-page.component';
import { PageNotFoundComponent } from '../../shared/pages/page-not-found/page-not-found.component';
import { SummaryComponent } from '../../shared/components/summary/summary.component';
import { MessageComponent } from '../../shared/components/message/message.component';

export const APP_ROUTES: Routes = [
  { path: 'summary', component: SummaryComponent, outlet: 'popup' },
  { path: 'messages', component: MessageComponent, outlet: 'popup' },

  { path: 'welcome', component: HomePageComponent },
  { path: '', redirectTo: 'welcome', pathMatch: 'full' },

  { path: 'store', loadChildren: () => import('../../store/routes/store.routes').then(r => r.STORE_ROUTES) },
  { path: 'security', loadChildren: () => import('../../security/routes/security.routes').then(r => r.SECURITY_ROUTES) },

  { path: '**', component: PageNotFoundComponent }
];
