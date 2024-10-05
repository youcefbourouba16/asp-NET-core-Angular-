import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service'; // Make sure the AuthService is imported
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) {}

  // CanActivate method now checks authentication from the backend
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const isLoginRoute = state.url.includes('/login');

    if (this.authService.isAuthenticated()) {
      // If the user is authenticated and trying to access the login page, redirect them to the disconnect page
      if (isLoginRoute) {
        if (confirm('Are you sure you want to Log Out?')) {
          localStorage.removeItem('token');

          return true;
        }
        
          return false;
        
      }
      return true; // Allow access to other authenticated routes
    }

    if (isLoginRoute) {
      return true; // Allow access to the login page if not authenticated
    }

    this.router.navigate(['/login']); // Redirect to the login page if not authenticated
    return false;
  }
}
