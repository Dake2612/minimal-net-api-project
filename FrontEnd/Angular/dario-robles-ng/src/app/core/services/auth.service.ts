import { inject, Injectable } from "@angular/core";
import { ConfigService } from "./config.service";
import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { AppUserAuth } from "../models/app-user-auth";
import { catchError, firstValueFrom, map, throwError } from "rxjs";

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  public redirectUrl: string = '';
  private _isAuthenticated: boolean = false;

  public appUserAuth = new AppUserAuth();

  private authTokenUrl: string = '';
  private configService = inject(ConfigService);
  private http = inject(HttpClient);

  constructor() {
    this.authTokenUrl = `${this.configService.getValue('KEYCLOAK_URL')}/realms/${this.configService.getValue('KEYCLOAK_REALM')}/protocol/openid-connect/token`;
    this.appUserAuth = this.getUserLoggedIn();
    this.setUserLoggedIn(this.appUserAuth);
  }

  public async login(username: string, password: string): Promise<AppUserAuth> {
    const body = new URLSearchParams();
    body.set('grant_type', 'password');
    body.set('client_id', this.configService.getValue('KEYCLOAK_CLIENT_ID'));
    body.set('username', username);
    body.set('password', password);

    const options = {
      headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
    }

    return await firstValueFrom(this.http.post<AppUserAuth>(this.authTokenUrl, body.toString(), options)
      .pipe(
        map(appUserAuth => {
          appUserAuth.isAuthenticated = true;
          this.setUserLoggedIn(appUserAuth);
          this.appUserAuth = appUserAuth;
          return appUserAuth
        }),
        catchError(this.handleError)
      )
    )
  }

  private setUserLoggedIn(appUserAuth: AppUserAuth) {
    this._isAuthenticated = appUserAuth.isAuthenticated;
    sessionStorage.setItem('appUserAuth', JSON.stringify(appUserAuth));
  }

  private getUserLoggedIn(): AppUserAuth {
    let appUserAuth = JSON.parse(sessionStorage.getItem('appUserAuth')!);
    appUserAuth = appUserAuth || new AppUserAuth();
    return appUserAuth;
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error: ', error);
    if (error.error instanceof Error) {
      const errMessage = error.error.message;
      return throwError(() => errMessage);
    }
    return throwError(() => error || 'Server error');
  }

  public isAuthenticated(authenticated?: boolean): boolean {
    if (authenticated !== undefined) {
      this._isAuthenticated = authenticated;
    }
    return this._isAuthenticated;
  }
}
