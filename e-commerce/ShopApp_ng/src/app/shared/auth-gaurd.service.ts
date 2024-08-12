import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from './auth.service'; // Make sure the AuthService is imported
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const isLoginRoute = state.url.includes('/login');

    if (this.authService.isAuthenticated()) {
      // If the user is authenticated and trying to access the login page, redirect them to the disconnect page
      if (isLoginRoute) {
        if (confirm('Are you sure you want to Log Out?')) {
          localStorage.removeItem('token');

          return true;
        }
        this.router.navigate(['']); // Redirect to a disconnect page or home
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
