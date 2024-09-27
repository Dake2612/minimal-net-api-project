import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-order-edit-info',
  standalone: true,
  imports: [],
  templateUrl: './order-edit-info.component.html',
  styleUrl: './order-edit-info.component.scss'
})
export class OrderEditInfoComponent {
  public order = inject(ActivatedRoute).parent!.snapshot.data['order'];
}
