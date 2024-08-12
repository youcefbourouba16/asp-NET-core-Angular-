import { Component } from '@angular/core';
import { AuthService } from '../../shared/auth.service';
import { Router } from '@angular/router';
import { AccountViewModel } from '../../Models/account-view-model';
import { LoginResponse } from '../../Interfaces/login-response';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: ``
})
export class LoginComponent {
  vm: AccountViewModel = { email: '', password: '' };
  errorMessage: string | null = null;

  constructor(private authService: AuthService, private router: Router) {}

  onSubmit() {
    this.authService.login(this.vm).subscribe(
      (response: LoginResponse) => {
        // Handle successful login response
        console.log(response);
      },
      (error: any) => {
        // Handle login error
        this.errorMessage = error.message || 'An error occurred during login';
      }
    );
  }
}
