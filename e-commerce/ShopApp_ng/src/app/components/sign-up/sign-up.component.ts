import { Component } from '@angular/core';
import { AccountSigninModel } from '../../Models/account-signin-model';
import { AuthService } from '../../shared/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styles: []
})
export class SignUpComponent {
  vm: AccountSigninModel = new AccountSigninModel(); // Model data for the form
  errorMessage: string | null = null;

  constructor(private authService: AuthService, private router: Router) {}

  // Form submission handler
  onSubmit() {
    if (this.vm.password !== this.vm.conffpassword) {
      this.errorMessage = 'Passwords do not match.';
      return;
    }

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
