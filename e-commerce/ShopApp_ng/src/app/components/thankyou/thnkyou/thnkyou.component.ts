import { Component, OnInit } from '@angular/core';
import { CartService } from '../../../shared/Cart/cart.service';

@Component({
  selector: 'app-thnkyou',
  templateUrl: './thnkyou.component.html',
  styles: ``
})
export class ThnkyouComponent implements OnInit {
  constructor( private cartService: CartService){}


  ngOnInit(): void {
    this.cartService.removeAllCart()
  }

  


}
