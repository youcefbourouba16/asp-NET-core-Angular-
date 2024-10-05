import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { CartViewModel } from '../../Models/productViewModel/cart-view-model';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  public cartItemList : any =[]
  public productList = new BehaviorSubject<CartViewModel[]>([]);


  constructor(private toastr : ToastrService) { }
  getProducts(){
    return this.productList.asObservable();
  }

  setProduct(product : any){
    this.cartItemList.push(...product);
    this.productList.next(product);
  }
  // Method to check if the product exists
  productExists(productId: number): boolean {
    // Get the current list of products
    const currentList = this.productList.getValue();
    // Check if the product already exists in the list
    return currentList.some((item: any) => item.id === productId);
  }

  addtoCart(product: CartViewModel) {
    const currentProducts = this.productList.getValue();
    
    // Check if the product already exists
    const existingProductIndex = currentProducts.findIndex(p => p.id === product.id);
    
    if (existingProductIndex === -1) {
      // Product does not exist, add it
      this.cartItemList.push(product);
      this.productList.next([...this.cartItemList]); // Push a new reference to the BehaviorSubject
      this.toastr.info('Item Added', 'Item successfully added to the cart.');
    } else {
      // Product already exists, show error
      this.toastr.error('Error', 'Item already exists in the cart!');
    }
  }
  
  getTotalPrice() : number{
    let grandTotal = 0;
    this.cartItemList.map((a:any)=>{
      grandTotal += (a.price*a.quantityBuying);
    })
    return grandTotal;
  }
  removeCartItem(product: any){
    this.cartItemList.map((a:any, index:any)=>{
      if(product.id=== a.id){
        this.cartItemList.splice(index,1);
      }
    })
    this.productList.next(this.cartItemList);
  }
  removeAllCart(){
    this.cartItemList = []
    this.productList.next(this.cartItemList);
  }
}
