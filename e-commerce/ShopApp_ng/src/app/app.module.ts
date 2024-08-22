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
import { AddColorComponent } from './components/add-color/add-color.component';

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
    DetailsComponent
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
        allowedDomains: ['localhost:5019'], // Adjust to your backend domain
        disallowedRoutes: ['localhost:5019/api/auth/login'], // Routes that shouldn't include the token
      },
    }),
  ],
  providers: [
    provideClientHydration(),
    provideHttpClient(withFetch()),
    JwtHelperService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
