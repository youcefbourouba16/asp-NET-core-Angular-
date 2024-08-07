import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [],
  templateUrl: './nav-bar.component.html',
  styles: ``
})
export class NavBarComponent {

  constructor(private router: Router) {}
  callLoginFrom(){
    this.router.navigate(['/login']);
  
  }
}
