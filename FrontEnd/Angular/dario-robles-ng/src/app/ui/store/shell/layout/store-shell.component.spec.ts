import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoreShellComponent } from './store-shell.component';

describe('StoreShellComponent', () => {
  let component: StoreShellComponent;
  let fixture: ComponentFixture<StoreShellComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StoreShellComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StoreShellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
