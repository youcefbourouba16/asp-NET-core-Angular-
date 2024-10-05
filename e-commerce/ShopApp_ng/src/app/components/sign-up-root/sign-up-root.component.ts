import { Component, EventEmitter, Input, Output } from '@angular/core';
import { AccountSigninModel } from '../../Models/account-signin-model';

@Component({
  selector: 'app-sign-up-root',
  templateUrl: './sign-up-root.component.html',
  styles: ``
})
export class SignUpRootComponent {

  @Input() vm: AccountSigninModel = new AccountSigninModel(); // Form model data
  @Input() errorMessage: string | null = null; // Error message from parent
}
