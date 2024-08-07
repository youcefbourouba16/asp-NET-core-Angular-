import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AccountViewModel } from '../Models/account-view-model';
import { LoginResponse } from '../Interfaces/login-response'; // Ensure this path is correct
import { AccountSigninModel } from '../Models/account-signin-model';
import { SignUpResponse } from '../Interfaces/sign-up-response';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5019/api/account';

  constructor(private http: HttpClient) {}

  login(vm: AccountViewModel): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.apiUrl}/login`, vm);
  }

  signup(vm:AccountSigninModel) : Observable<SignUpResponse>{
    return this.http.post<SignUpResponse>(`${this.apiUrl}/login`, vm);
  }
}
