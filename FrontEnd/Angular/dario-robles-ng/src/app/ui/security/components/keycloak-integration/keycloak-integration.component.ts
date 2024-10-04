import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { KeycloakService } from '../../../../infraestructure/keycloak/keycloak.service';
import { AuthService } from '../../../../core/services/auth.service';

@Component({
  selector: 'app-keycloak-integration',
  standalone: true,
  imports: [],
  templateUrl: './keycloak-integration.component.html',
  styleUrl: './keycloak-integration.component.scss'
})
export class KeycloakIntegrationComponent {
  private route: ActivatedRoute = inject(ActivatedRoute);
  private router: Router = inject(Router);
  private keycloakService: KeycloakService = inject(KeycloakService);
  private authService: AuthService = inject(AuthService);

  public async ngOnInit() {
    if (this.keycloakService.isLoggedIn()) {
      await this.authService.LoggedInFromKeycloak();
    }
    const encodedUrl = this.route.snapshot.params['redirectUrl'];
    const decodedUrl = atob(encodedUrl);
    this.router.navigate([decodedUrl]);
  }
}
