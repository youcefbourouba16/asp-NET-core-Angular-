import { Component, OnInit } from '@angular/core';
import { CartService } from '../../shared/Cart/cart.service';
import { CartViewModel } from '../../Models/productViewModel/cart-view-model';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styles: ``
})
export class CartComponent implements OnInit {
  public products : CartViewModel[] = [];
  public grandTotal !: number;
  constructor(private cartService : CartService) { }

  ngOnInit(): void {
    this.cartService.getProducts()
    .subscribe(res=>{
      this.products = res;
      this.grandTotal = this.cartService.getTotalPrice();
    })
  }
  increaseQuantity(index : number){
    if (this.products[index].quantityBuying < this.products[index].quantity) {
      this.products[index].quantityBuying++;
    }
  }
  decreaseQuantity(index : number){
    if(this.products[index].quantityBuying>1){
      this.products[index].quantityBuying--;
    }
  }
  removeItem(index: number): void {
    this.products.splice(index, 1);
  }

}
