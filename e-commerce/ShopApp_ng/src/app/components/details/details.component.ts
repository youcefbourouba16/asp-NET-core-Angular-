import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../shared/products/product.service';
import { ActivatedRoute } from '@angular/router';
import { ProductDetails } from '../../Models/productViewModel/product-details';
import { CartService } from '../../shared/Cart/cart.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styles: ``
})
export class DetailsComponent  implements OnInit{
  
  productId: number | undefined;
  product: ProductDetails | undefined;
  sizeValueSelected: boolean = false;
  colorValueSelected: boolean =false;

  constructor(private route: ActivatedRoute,
              private productService : ProductService,
              private cartService : CartService) {}

  ngOnInit() {
    this.productId = Number(this.route.snapshot.paramMap.get('id'));
    this.loadProductDetails();
  }

  loadProductDetails(){
    this.productService.getProductByID(this.productId).subscribe({
      next: (data: ProductDetails ) => {
        console.log('Products loaded:', data);
        this.product = data;
      },
      error: (err) => {
        console.error('Error fetching product data', err);
      }
    });
    
  }
  addtocart(){
    this.cartService.addtoCart(this.product);
  }
  onChangeSize(size : any){
    this.sizeValueSelected=true
  }
  onChangeColor(color : any){
    this.colorValueSelected=true
  }

}
