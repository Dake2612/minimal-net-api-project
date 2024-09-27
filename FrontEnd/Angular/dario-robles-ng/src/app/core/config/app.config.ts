import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter, withComponentInputBinding, withHashLocation } from '@angular/router';


import { provideClientHydration } from '@angular/platform-browser';
import { APP_ROUTES } from '../../ui/main/routes/app.routes';
import { provideRepositories } from '../../infraestructure/providers/repositories.provider';
import { provideAppInitialize } from '../../infraestructure/providers/app-initializer.provider';
import { provideHttpClient, withFetch } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(APP_ROUTES, withHashLocation(), withComponentInputBinding()),
    provideClientHydration(),
    provideAppInitialize(),
    provideHttpClient(withFetch()),
    provideRepositories()
  ]
};
