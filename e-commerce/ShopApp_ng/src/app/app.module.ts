import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, provideHttpClient, withFetch } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { IndexComponent } from './components/index/index.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { JwtHelperService, JwtModule } from '@auth0/angular-jwt';
import { LogOutComponent } from './components/log-out/log-out.component';
import { ShopComponent } from './components/shop/shop.component';
import { DetailsComponent } from './components/details/details.component';
import { CartComponent } from './components/cart/cart.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';

export function tokenGetter() {
  return localStorage.getItem('token');
}
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    IndexComponent,
    SignUpComponent,
    NavBarComponent,
    LogOutComponent,
    ShopComponent,
    DetailsComponent,
    CartComponent,
    LoadingSpinnerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule,
    
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:5019','http://youcefbourouba-001-site1.ltempurl.com'], // Adjust to your backend domain
        disallowedRoutes: ['localhost:5019/api/auth/login','http://youcefbourouba-001-site1.ltempurl.com/api/auth/login'], // Routes that shouldn't include the token
      },
    }),
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot()
  ],
  providers: [
    provideClientHydration(),
    provideHttpClient(withFetch()),
    JwtHelperService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
