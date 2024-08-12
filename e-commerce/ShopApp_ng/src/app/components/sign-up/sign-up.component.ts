import { Component } from '@angular/core';
import { AccountSigninModel } from '../../Models/account-signin-model';
import { AuthService } from '../../shared/auth.service';
import { LoginResponse } from '../../Interfaces/login-response';
import { Router } from '@angular/router';
@Component({
  selector: 'app-signUp',
  templateUrl: './sign-up.component.html',
  styles: ``
})
export class SignUpComponent {

  vm: AccountSigninModel = new AccountSigninModel()
  errorMessage: string | null = null;

  
  constructor(private authService: AuthService, private router: Router) {}

  onSubmit() {
    this.authService.signup(this.vm).subscribe({
      next: () => {
        this.router.navigate(['/login']);
      },
      error: (err) => {
        this.errorMessage = 'Registration failed. Please try again.';
        console.error(err);
      }
    });
  }
}
