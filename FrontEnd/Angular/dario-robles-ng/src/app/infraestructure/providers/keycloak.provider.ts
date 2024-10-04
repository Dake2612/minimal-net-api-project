import { APP_INITIALIZER, Provider } from "@angular/core";
import { KeycloakService } from "../keycloak/keycloak.service";
import { ConfigService } from "../../core/services/config.service";

export function initializeKeycloak(keycloak: KeycloakService) {
  return () => keycloak.init();
}

export function provideKeycloak(): Provider {
  return {
    provide: APP_INITIALIZER,
    useFactory: initializeKeycloak,
    deps: [KeycloakService, ConfigService],
    multi: true
  }
}
