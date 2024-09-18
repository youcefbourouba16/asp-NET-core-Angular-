import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { IndexComponent } from './components/index/index.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { AuthGuard } from './shared/auth-gaurd.service';
import { LogOutComponent } from './components/log-out/log-out.component';
import { ShopComponent } from './components/shop/shop.component';
import { DetailsComponent } from './components/details/details.component';
import { CartComponent } from './components/cart/cart.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent, canActivate: [AuthGuard] },
  { path: 'signUp', component: SignUpComponent },
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: IndexComponent },
  { path: 'logOut', component: LogOutComponent }, // Or handle it with a service
  { path: 'shop', component: ShopComponent },
  { path: 'cart', component: CartComponent },
  { path: 'product-detail/:id', component: DetailsComponent }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
