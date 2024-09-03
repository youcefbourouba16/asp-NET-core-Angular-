import { Component, OnInit } from '@angular/core';
import { CartService } from '../../shared/Cart/cart.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styles: ``
})
export class NavBarComponent implements OnInit {

  public totalItem : number = 0;
  public searchTerm !: string;
  constructor(private cartService : CartService,private router: Router) { }

  ngOnInit(): void {
    this.cartService.getProducts()
    .subscribe(res=>{
      this.totalItem = res.length;
    })
  }
  resetShopComponent(): void {
    // Navigate to the shop page
    this.router.navigate(['/shop']).then(() => {
      // Refresh or reset logic can be handled here
      this.cartService.getProducts().subscribe(res => {
        this.totalItem = res.length;
      });
    });
  }
}
