import { Component, Input } from '@angular/core';
import { OrderModel } from '../../../../../business/application/models/orders/order.model';

@Component({
  selector: 'app-order-detail-page',
  standalone: true,
  imports: [],
  templateUrl: './order-detail-page.component.html',
  styleUrl: './order-detail-page.component.scss'
})
export class OrderDetailPageComponent {
  @Input() orderId?: string;
  @Input() searchQuery?: string;
  @Input() orderBy?: string;

  @Input() order!: OrderModel;
}
