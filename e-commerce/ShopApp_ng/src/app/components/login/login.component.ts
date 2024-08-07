import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AuthService } from '../../shared/auth.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AccountViewModel } from '../../Models/account-view-model';
import { LoginResponse } from '../../Interfaces/login-response';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: ``
})

export class LoginComponent   {
  vm: AccountViewModel = { email: '', password: '' };
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
