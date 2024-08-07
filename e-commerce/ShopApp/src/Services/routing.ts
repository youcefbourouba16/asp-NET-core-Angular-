import { RouterModule, Routes } from "@angular/router";
import { AppComponent } from "../app/app.component";
import { LoginFormComponent } from "../app/User/login-form/login-form.component";




export const routes: Routes = [
    { path: '', component: AppComponent },
    { path: 'login', component: LoginFormComponent }
  ];
  
  export const routingModule = RouterModule.forRoot(routes);