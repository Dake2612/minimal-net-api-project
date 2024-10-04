import { Routes } from "@angular/router";
import { SecurityShellComponent } from "../shell/layout/security-shell.component";
import { LoginPageComponent } from "../pages/login-page/login-page.component";
import { SignupPageComponent } from "../pages/signup-page/signup-page.component";
import { ForgotPasswordPageComponent } from "../pages/forgot-password-page/forgot-password-page.component";
import { KeycloakIntegrationComponent } from "../components/keycloak-integration/keycloak-integration.component";

export const SECURITY_ROUTES: Routes = [
  {
    path: '', component: SecurityShellComponent,
    children: [
      { path: '', redirectTo: 'login', pathMatch: 'full' },
      { path: 'login', component: LoginPageComponent },
      { path: 'signup', component: SignupPageComponent },
      { path: 'forgot-password', component: ForgotPasswordPageComponent },
      { path: 'keycloak-integration/:redirectUrl', component: KeycloakIntegrationComponent }
    ]
  }
]
