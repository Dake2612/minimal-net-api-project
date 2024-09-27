import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OrderEditInfoComponent } from './order-edit-info.component';

describe('OrderEditInfoComponent', () => {
  let component: OrderEditInfoComponent;
  let fixture: ComponentFixture<OrderEditInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [OrderEditInfoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderEditInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
