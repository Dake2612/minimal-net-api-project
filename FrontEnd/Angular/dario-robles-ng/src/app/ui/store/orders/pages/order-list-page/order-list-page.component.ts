import { Component, Input } from '@angular/core';
import { OrderModel } from '../../../../../business/application/models/orders/order.model';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-order-list-page',
  standalone: true,
  imports: [
    DatePipe
  ],
  templateUrl: './order-list-page.component.html',
  styleUrl: './order-list-page.component.scss'
})
export class OrderListPageComponent {
  @Input() pageTitle?: string;
  @Input() orders: OrderModel[] = [];
}
