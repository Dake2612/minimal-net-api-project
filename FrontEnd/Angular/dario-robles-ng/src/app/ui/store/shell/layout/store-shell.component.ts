import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-store-shell',
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  templateUrl: './store-shell.component.html',
  styleUrl: './store-shell.component.scss'
})
export class StoreShellComponent {

}
