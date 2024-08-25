import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../shared/products/product.service';
import { ActivatedRoute } from '@angular/router';
import { ProductDetails } from '../../Models/productViewModel/product-details';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styles: ``
})
export class DetailsComponent  implements OnInit{
  
  productId: number | undefined;
  product: ProductDetails | undefined;
  zbi: string | '#ff0000' = '#ff0000';

  constructor(private route: ActivatedRoute,private productService : ProductService) {}

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

}
