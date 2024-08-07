import { Component } from '@angular/core';
import { AccountSigninModel } from '../../Models/account-signin-model';
import { AuthService } from '../../shared/auth.service';
import { LoginResponse } from '../../Interfaces/login-response';

@Component({
  selector: 'app-signUp',
  templateUrl: './sign-up.component.html',
  styles: ``
})
export class SignUpComponent {

  vm: AccountSigninModel = new AccountSigninModel()
  errorMessage: string | null = null;

  constructor(private authService: AuthService) {}

  onSubmit() {
    this.authService.login(this.vm).subscribe(
      (response: LoginResponse) => {
        console.log('Login successful:', response);
        // Handle successful login (e.g., redirect to a different page)
      },
      (error) => {
        console.error('Login failed:', error);
        this.errorMessage = 'Login failed. Please check your username and password.';
      }
    );
  }
}
