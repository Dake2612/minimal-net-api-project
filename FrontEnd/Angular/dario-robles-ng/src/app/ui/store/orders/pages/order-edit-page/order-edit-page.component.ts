import { Component, Input } from '@angular/core';
import { OrderModel } from '../../../../../business/application/models/orders/order.model';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-order-edit-page',
  standalone: true,
  imports: [RouterLink, RouterOutlet],
  templateUrl: './order-edit-page.component.html',
  styleUrl: './order-edit-page.component.scss'
})
export class OrderEditPageComponent {
  @Input() orderId?: string;
  @Input() order!: OrderModel;
}
