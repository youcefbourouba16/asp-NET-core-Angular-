import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../shared/products/product.service';
import { ActivatedRoute } from '@angular/router';
import { ProductDetails } from '../../Models/productViewModel/product-details';
import { CartService } from '../../shared/Cart/cart.service';
import { CartViewModel } from '../../Models/productViewModel/cart-view-model';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styles: ``
})
export class DetailsComponent implements OnInit {

  productId: number | undefined;
  product: ProductDetails= new ProductDetails();
  productTocart: CartViewModel = new CartViewModel();
  sizeValueSelected: boolean = false;
  colorValueSelected: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private cartService: CartService
  ) {}

  ngOnInit() {
    this.productId = Number(this.route.snapshot.paramMap.get('id'));
    this.loadProductDetails();
  }

  loadProductDetails() {
    if (this.productId) {
      this.productService.getProductByID(this.productId).subscribe({
        next: (data: ProductDetails) => {
          console.log('Product loaded:', data);
          this.product = data;
          // Reset the cart product details when a new product is loaded
          this.productTocart = new CartViewModel();
          this.sizeValueSelected = false;
          this.colorValueSelected = false;
        },
        error: (err) => {
          console.error('Error fetching product data', err);
        }
      });
    }
  }

  addtocart(product: ProductDetails) {
    if (this.sizeValueSelected && this.colorValueSelected ) {
      this.productTocart.id = product.id;
      this.productTocart.name = product.name;
      this.productTocart.price = product.price;
      this.productTocart.quantity=product.quantity
      this.productTocart.imageURL = product.imageURL;

      this.cartService.addtoCart(this.productTocart);
      localStorage.setItem('cartItems', JSON.stringify(this.productTocart));

      console.log('Product added to cart:', this.productTocart);
    } else {
      console.log('Please select both size and color before adding to the cart.');
    }
  }

  onChangeSize(size: string) {
    this.sizeValueSelected = true;
    this.productTocart.size = size;
  }

  onChangeColor(color: string) {
    this.colorValueSelected = true;
    this.productTocart.color = color;
  }

  increaseQuantity(){
    this.productTocart.quantityBuying++;
  }
  decreaseQuantity(){
    if(this.productTocart.quantityBuying>1){
      this.productTocart.quantityBuying--;
    }
    
  }
}
