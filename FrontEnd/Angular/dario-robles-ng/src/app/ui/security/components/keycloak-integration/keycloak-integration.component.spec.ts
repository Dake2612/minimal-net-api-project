import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KeycloakIntegrationComponent } from './keycloak-integration.component';

describe('KeycloakIntegrationComponent', () => {
  let component: KeycloakIntegrationComponent;
  let fixture: ComponentFixture<KeycloakIntegrationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [KeycloakIntegrationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KeycloakIntegrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
