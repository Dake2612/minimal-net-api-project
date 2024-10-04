import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter, withComponentInputBinding, withHashLocation } from '@angular/router';


import { provideClientHydration } from '@angular/platform-browser';
import { APP_ROUTES } from '../../ui/main/routes/app.routes';
import { provideRepositories } from '../../infraestructure/providers/repositories.provider';
import { provideAppInitialize } from '../../infraestructure/providers/app-initializer.provider';
import { provideKeycloak } from '../../infraestructure/providers/keycloak.provider';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { authInterceptor } from '../../infraestructure/interceptors/auth.interceptor';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideDateAdapter } from '../../infraestructure/providers/date-adapter.provider';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(APP_ROUTES, withHashLocation(), withComponentInputBinding()),
    provideClientHydration(),
    provideAppInitialize(),
    provideHttpClient(withFetch(), withInterceptors([authInterceptor])),
    provideRepositories(),
    provideKeycloak(),
    provideDateAdapter(),
    provideAnimationsAsync()
  ]
};
