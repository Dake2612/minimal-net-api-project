import { HttpInterceptorFn } from '@angular/common/http';
import { AuthService } from '../../core/services/auth.service';
import { inject } from '@angular/core';
import { ConfigService } from '../../core/services/config.service';

export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const configService = inject(ConfigService);
  const authService = inject(AuthService);

  if (req.url.includes(configService.getValue('ORDERS_URL'))) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${authService.appUserAuth.access_token}`
      }
    });
  }

  return next(req);
};
