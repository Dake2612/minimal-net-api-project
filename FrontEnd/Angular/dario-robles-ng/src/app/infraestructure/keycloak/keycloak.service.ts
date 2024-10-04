import { inject, Injectable } from '@angular/core';
import Keycloak, { KeycloakProfile } from 'keycloak-js';
import { ConfigService } from '../../core/services/config.service';

@Injectable({
  providedIn: 'root'
})
export class KeycloakService {
  private keycloak!: Keycloak;
  private authenticated: boolean = false;
  private configService = inject(ConfigService);

  constructor() { }

  public async init(): Promise<boolean> {
    await this.configService.getConfig();
    this.keycloak = new Keycloak({
      url: this.configService.getValue('KEYCLOAK_URL'),
      realm: this.configService.getValue('KEYCLOAK_REALM'),
      clientId: this.configService.getValue('KEYCLOAK_CLIENT_ID')
    })
    return this.keycloak.init({
      onLoad: 'check-sso',
      checkLoginIframe: false,
      silentCheckSsoRedirectUri: `${window.location.origin}/keycloak/silent-check-sso.html`,
      pkceMethod: 'S256'
    }).then(authenticated => {
      this.authenticated = authenticated;
      console.log(`User is ${authenticated ? 'authenticated' : 'not authenticated'}`);
      return authenticated;
    }).catch(error => {
      console.error('Failed to initialize Keycloak', error);
      this.authenticated = false;
      return false;
    })
  }

  public login(redirectUri: string): Promise<void> {
    return this.keycloak.login({ redirectUri });
  }

  public logout(redirectUri: string): Promise<void> {
    return this.keycloak.logout({ redirectUri });
  }

  public isLoggedIn(): boolean {
    return this.keycloak.authenticated ?? false;
  }

  public getRefreshToken(): string {
    return this.keycloak.refreshToken ?? '';
  }

  public async getToken(): Promise<string> {
    if (this.keycloak.isTokenExpired(30)) {
      try {
        const refreshed = await this.keycloak.updateToken(30);
        if (refreshed) {
          return this.keycloak.token ?? '';
        } else {
          throw new Error('Could not refresh token');
        }
      } catch (error) {
        console.error('Failed to refresh token', error);
        this.authenticated = false;
      }
    }

    return this.keycloak.token ?? '';
  }

  public async getProfile(): Promise<KeycloakProfile> {
    if (this.isLoggedIn()) {
      try {
        return await this.keycloak.loadUserProfile();
      } catch (error) {
        console.error('Failed to load user profile', error);
        throw new Error('Failed to load user profile');
      }
    } else {
      throw new Error('User is not authenticated');
    }
  }
}
