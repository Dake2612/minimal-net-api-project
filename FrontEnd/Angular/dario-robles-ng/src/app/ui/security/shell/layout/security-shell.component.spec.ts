import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SecurityShellComponent } from './security-shell.component';

describe('SecurityShellComponent', () => {
  let component: SecurityShellComponent;
  let fixture: ComponentFixture<SecurityShellComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SecurityShellComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SecurityShellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
