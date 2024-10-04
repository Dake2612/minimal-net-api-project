import { Component, inject, Input, OnInit } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from "@angular/material/icon";
import { MatMenuModule } from "@angular/material/menu";
import { MatButtonModule } from '@angular/material/button';
import { AsyncPipe } from '@angular/common';
import { Observable } from 'rxjs';
import { MatSidenav } from '@angular/material/sidenav';
import { AuthService } from '../../../../../core/services/auth.service';
import { KeycloakProfile } from 'keycloak-js';
import { CapitalizePipe } from '../../../../shared/pipes/capitalize.pipe';
@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MatToolbarModule,
    MatIconModule,
    MatMenuModule,
    MatButtonModule,
    AsyncPipe,
    CapitalizePipe
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit{
  @Input() isHandset$!: Observable<boolean>;
  @Input() drawer!: MatSidenav;

  private authService = inject(AuthService);
  public profile?: KeycloakProfile;

  public ngOnInit(): void {
    this.authService.getUserProfile().then(profile => {
      this.profile = profile;
    });
  }

  public signOut() {
    this.authService.logout();
  }
}
