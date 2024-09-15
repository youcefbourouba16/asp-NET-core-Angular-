import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-loading-spinner',
  templateUrl: './loading-spinner.component.html',
  styles: ``
})
export class LoadingSpinnerComponent {

  @Input() isLoading: boolean = false;
}
