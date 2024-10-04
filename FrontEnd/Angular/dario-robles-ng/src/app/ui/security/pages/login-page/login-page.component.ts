import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../../../core/services/auth.service';
@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [
    ReactiveFormsModule
  ],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})
export class LoginPageComponent implements OnInit{
  private fb = inject(FormBuilder);
  private authService = inject(AuthService);
  private router = inject(Router);

  public loginForm!: FormGroup;

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: new FormControl(''),
      password: new FormControl(''),
    })
  }

  public async onLogin() {
    const username = this.loginForm.value.username;
    const password = this.loginForm.value.password;

    //const auth = await this.authService.login(username, password);

    //if (auth.isAuthenticated) {
    //  if (this.authService.redirectUrl) {
    //    const redirectUrl = this.authService.redirectUrl;
    //    this.authService.redirectUrl = '';
    //    this.router.navigate([redirectUrl]);
    //  } else {
    //    this.router.navigate(['/welcome']);
    //  }
    //} else {
    //  console.log('Login failed');
    //}
  }
}
