import { Component, inject, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { SharedDataService } from '../../../infraestructure/comunication/shared-data.service';
import { OrderModel } from '../../../business/application/models/orders/order.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit{
  private SharedDataService = inject(SharedDataService);
  public title = 'dario-robles-ng';
  public name = 'Dario';
  public order = new OrderModel();

  public ngOnInit(): void {
    this.order.Code = '0000001';
    this.order.OrderId = '3F2504E0-4F89-11D3-9A0C-0305E82C3301'
  }

  public onClickMe(): void {
    console.log('Clicked!');
    console.log(this.SharedDataService.getFullName(this.name, 'Robles'));
  }
}
