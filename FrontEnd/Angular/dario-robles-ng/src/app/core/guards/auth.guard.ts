import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';

export const authGuard: CanActivateFn = async (route, state) => {
  const authService = inject(AuthService);
  const locationStrategy = inject(LocationStrategy);

  let redirectUrl = window.location.origin;
  const encodeUrl = btoa(state.url);
  if (locationStrategy instanceof HashLocationStrategy) {
    redirectUrl += `/#/security/keycloak-integration/${encodeUrl}`;
  } else {
    redirectUrl += `/security/keycloak-integration/${encodeUrl}`;
  }

  if (!authService.isAuthenticated()) {
    await authService.login(redirectUrl);
  }

  return authService.isAuthenticated();
};
