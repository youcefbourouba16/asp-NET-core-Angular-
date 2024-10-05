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
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = environment.apiUrl+'/account';

  constructor(private http: HttpClient, private router: Router, private jwtHelper: JwtHelperService) {}

  // Login method, with 'withCredentials' to send and receive cookies
  login(vm: AccountViewModel): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, vm, { withCredentials: true }).pipe(
      tap((response: LoginResponse) => {
        // No need to handle token manually, it's in HttpOnly cookie
        sessionStorage.setItem('username', response.username);
        this.router.navigate(['/']);
      })
    );
  }

  signup(vm: AccountSigninModel): Observable<SignUpResponse> {
    return this.http.post<SignUpResponse>(`${this.apiUrl}/register`, vm);
  }

  // Authenticated check (now you can only check by hitting a backend endpoint)
  isAuthenticated(): Observable<boolean> {
    return this.http.get<boolean>(`${this.apiUrl}/isAuthenticated`, { withCredentials: true });
  }

  // Logout method, sends a request to delete the cookie
  logout(): void {
    this.http.post(`${this.apiUrl}/logout`, {}, { withCredentials: true }).subscribe(() => {
      this.router.navigate(['/login']);
    });
  }
}
