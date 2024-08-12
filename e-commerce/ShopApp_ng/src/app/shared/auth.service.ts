import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AccountViewModel } from '../Models/account-view-model';
import { LoginResponse } from '../Interfaces/login-response';
import { AccountSigninModel } from '../Models/account-signin-model';
import { SignUpResponse } from '../Interfaces/sign-up-response';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5019/api/account';

  constructor(private http: HttpClient, private router: Router, private jwtHelper: JwtHelperService) {}

  login(vm: AccountViewModel): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, vm).pipe(
      tap((response: LoginResponse) => {
        localStorage.setItem('token', response.token);
        this.router.navigate(['/']);
      })
    );
  }

  signup(vm: AccountSigninModel): Observable<SignUpResponse> {
    return this.http.post<SignUpResponse>(`${this.apiUrl}/register`, vm);
  }

  isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    return !!token && !this.jwtHelper.isTokenExpired(token);
  }

  logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }
}
