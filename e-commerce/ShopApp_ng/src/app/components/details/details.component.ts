import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../shared/products/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductDetails } from '../../Models/productViewModel/product-details';
import { CartService } from '../../shared/Cart/cart.service';
import { CartViewModel } from '../../Models/productViewModel/cart-view-model';
import { DialogComponent } from '../dialog/dialog.component';
import { MatDialog } from '@angular/material/dialog';


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
  isLoading: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private productService: ProductService,
    private cartService: CartService,
    private router: Router,
    public dialog: MatDialog
  ) {}

  ngOnInit() {
    this.router.events.subscribe(() => {
      
        this.productId = Number(this.route.snapshot.paramMap.get('id'));
        this.loadProductDetails();
    });
  }

  loadProductDetails() {
    if (this.productId) {
      this.isLoading = true;
      this.productService.getProductByID(this.productId).subscribe({
        next: (data: ProductDetails) => {
          console.log('Product loaded:', data);
          this.product = data;
          // Reset the cart product details when a new product is loaded
          this.productTocart = new CartViewModel();
          this.sizeValueSelected = false;
          this.colorValueSelected = false;
          this.isLoading = false;
        },
        error: (err) => {
          console.error('Error fetching product data', err);
          this.isLoading = false;
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
      this.openDialog();

      
    
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

  openDialog(){

    const dialogRef = this.dialog.open(DialogComponent, {
      width: '300px',
      data: {
        title: 'Confirmation',  // Custom title
        message: 'Voulez-vous continuer vos achats ou aller à votre panier ?',  // Custom message
        cancelButtonText: 'Continuer les achats',  // Custom cancel button text
        confirmButtonText: 'Aller au panier'  // Custom confirm button text
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.router.navigate(['/cart']);
        
      } else {
        this.router.navigate(['/shop']);
      }
    });
  }
}
