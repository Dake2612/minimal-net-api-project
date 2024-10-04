import { AfterViewInit, Component, inject, Input, OnInit, ViewChild } from '@angular/core';
import { OrderModel } from '../../../../../business/application/models/orders/order.model';
import { AsyncPipe, DatePipe } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { PaginatedResult } from '../../../../../infraestructure/agents/orders/dtos/paginated-result';
import { debounceTime, merge, startWith, Subject, switchMap } from 'rxjs';
import { LoadingService } from '../../../../shared/components/loading/services/loading.service';
import { GetOrdersUseCase } from '../../../../../business/application/use-cases/get-orders.use-case';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { GetStatesUseCase } from '../../../../../business/application/use-cases/get-states.use-case';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../../components/confirmation-dialog/confirmation-dialog.component';
import { DeleteOrderUseCase } from '../../../../../business/application/use-cases/delete-order.use-case';
import { MatSnackBar, MatSnackBarConfig } from '@angular/material/snack-bar';


@Component({
  selector: 'app-order-list-page',
  standalone: true,
  imports: [
    DatePipe,
    AsyncPipe,
    MatCardModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatIconModule,
    MatButtonModule
  ],
  templateUrl: './order-list-page.component.html',
  styleUrl: './order-list-page.component.scss'
})
export class OrderListPageComponent implements AfterViewInit, OnInit {
  @Input() pageTitle?: string;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;
  public orders: PaginatedResult<OrderModel> = new PaginatedResult<OrderModel>();

  public displayedColumns: string[] = ['OrderId', 'Code', 'CreatedAt', 'DeliverAt', 'State', 'Actions'];

  private loadingService = inject(LoadingService);
  private getOrderUseCase = inject(GetOrdersUseCase);
  private deleteOrderUseCase = inject(DeleteOrderUseCase);
  private router = inject(Router);
  public states = inject(GetStatesUseCase).execute();
  public dialog = inject(MatDialog);
  private snackBar = inject(MatSnackBar);
  private configSnackBar = new MatSnackBarConfig();

  private searchQueryChanged: Subject<string> = new Subject<string>();
  private currentSearchQuery: string = '';
  private stateChanged: Subject<string> = new Subject<string>();
  private selectedState: string = '';

  ngOnInit(): void {
    this.configSnackBar.duration = 3000;
  }
  ngAfterViewInit(): void {
    this.loadData();
  }

  private async loadData() {
    merge(
      this.paginator.page,
      this.sort.sortChange,
      this.stateChanged,
      this.searchQueryChanged.pipe(debounceTime(300))
    )
      .pipe(
        startWith({}),
        switchMap(() => {
          this.loadingService.show();
          return this.getOrderUseCase.execute(this.selectedState, this.currentSearchQuery, this.sort.active, this.sort.direction, this.paginator.pageIndex, this.paginator.pageSize)
            .then(result => result)
            .catch(() => new PaginatedResult<OrderModel>());
        }))
      .subscribe(result => {
        this.loadingService.hide();
        this.orders = result;
      });
  }

  public applySearchQuery(event: Event) {
    this.currentSearchQuery = (event.target as HTMLInputElement).value;
    this.searchQueryChanged.next(this.currentSearchQuery);
  }

  public onStateChange(event: any) {
    this.selectedState = event.value;
    this.stateChanged.next(this.selectedState);
  }

  public editOrder(order: OrderModel) {
    this.router.navigate(['/store/orders', order.OrderId, 'edit']);
  }

  public deleteOrder(order: OrderModel) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '350px',
      data: { order: order },
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(async result => {
      if (result) {
        await this.deleteOrderUseCase.execute(order.OrderId);
        this.snackBar.open('Record was successfully deleted.', undefined, this.configSnackBar);
        this.loadData();
      }
    });
  }
}
