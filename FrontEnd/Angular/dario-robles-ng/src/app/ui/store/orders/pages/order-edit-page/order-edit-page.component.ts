import { Component, inject, Input, OnInit } from '@angular/core';
import { OrderModel } from '../../../../../business/application/models/orders/order.model';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { GetStatesUseCase } from '../../../../../business/application/use-cases/get-states.use-case';
import { MatFormFieldModule } from '@angular/material/form-field';
import { AsyncPipe } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar, MatSnackBarConfig, MatSnackBarModule } from '@angular/material/snack-bar';
import { UpdateOrderUseCase } from '../../../../../business/application/use-cases/update-order.use-case';
import { CreateOrderUseCase } from '../../../../../business/application/use-cases/create-order.use-case';

@Component({
  selector: 'app-order-edit-page',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink,
    AsyncPipe,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatSelectModule,
    MatSnackBarModule,
    MatButtonModule,
    ReactiveFormsModule
  ],
  templateUrl: './order-edit-page.component.html',
  styleUrl: './order-edit-page.component.scss'
})
export class OrderEditPageComponent implements OnInit {
  @Input() orderId!: string;
  @Input() order!: OrderModel;

  public orderForm = inject(FormBuilder).group({
    orderId: [{ value: '', disabled: true }],
    code: ['', Validators.required],
    deliverAt: [{ value: new Date(), disabled: true }],
    createdAt: [new Date(), Validators.required],
    state: ['', Validators.required]
  });

  public states = inject(GetStatesUseCase).execute();
  public updateOrderUseCase = inject(UpdateOrderUseCase);
  public createOrderUseCase = inject(CreateOrderUseCase);
  public router = inject(Router);
  private snackBar = inject(MatSnackBar);
  private configSnackBar = new MatSnackBarConfig();

  ngOnInit(): void {
    this.setFormValues(this.order);
    if (this.orderId) {
      this.orderForm.controls['createdAt'].disable();
    } else {
      this.orderForm.controls['createdAt'].enable();
    }
    this.configSnackBar.duration = 3000;
  }

  private setFormValues(order: OrderModel) {
    if (order) {
      this.orderForm.setValue({
        orderId: order.OrderId,
        code: order.Code,
        deliverAt: order.DeliverAt,
        createdAt: order.CreatedAt,
        state: order.State
      });
    }
  }

  public async saveOrder() {
    const editOrder = this.getFormValues(this.orderForm);
    if (this.orderId) {
      const updatedOrder = await this.updateOrderUseCase.execute(this.orderId, editOrder);
      this.snackBar.open('Record was successfully updated.', undefined, this.configSnackBar);
    } else {
      const order = await this.createOrderUseCase.execute(editOrder);
      this.snackBar.open('Record was successfully created.', undefined, this.configSnackBar);
      this.router.navigate(['/store/orders', order.OrderId, 'edit']);
    }
  }

  public cancelOrder() {
    this.router.navigate(['/store/orders']);
  }

  private getFormValues(form: FormGroup): OrderModel {
    const order = new OrderModel();
    order.Code = form.get('code')?.value;
    order.CreatedAt = new Date(form.get('createdAt')?.value);
    order.DeliverAt = new Date(form.get('deliverAt')?.value);
    order.State = form.get('state')?.value;
    return order;
  }
}
