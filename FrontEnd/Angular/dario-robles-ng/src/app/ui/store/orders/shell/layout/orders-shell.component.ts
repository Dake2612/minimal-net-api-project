import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { AsyncPipe } from '@angular/common';
import { MatGridListModule } from '@angular/material/grid-list';

@Component({
  selector: 'app-orders-shell',
  standalone: true,
  imports: [
    RouterOutlet,
    AsyncPipe,
    RouterLink,
    RouterLinkActive,
    MatGridListModule,
    MatMenuModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule
  ],
  templateUrl: './orders-shell.component.html',
  styleUrl: './orders-shell.component.scss'
})
export class OrdersShellComponent {

}
