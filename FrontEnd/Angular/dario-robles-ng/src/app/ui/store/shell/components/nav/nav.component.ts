import { Component } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-nav',
  standalone: true,
  imports: [
    MatListModule,
    RouterLink,
    RouterLinkActive,
    MatIconModule,
  ],
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.scss'
})
export class NavComponent {
  public navItems = [
    { link: 'orders', label: 'Orders', icon: 'shopping_bag' },
    { link: 'items', label: 'Items', icon: 'list_alt' },
    { link: 'reports', label: 'Reports', icon: 'insert_chart_outlined' }
  ];
}
