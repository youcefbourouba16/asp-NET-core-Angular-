import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ProductViewModel } from '../../Models/productViewModel/product-view-model';
import { ProductService } from '../../shared/products/product.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styles: ``
})
export class ShopComponent implements OnInit{
  products: ProductViewModel[] = [];
  constructor(private productService: ProductService) { }
  ngOnInit(): void {
    this.loadProducts();
  }


  loadProducts(): void {
    this.productService.getProductNamesAndPrices().subscribe({
      next: (data: ProductViewModel[]) => {
        console.log('Products loaded:', data);
        this.products = data;
      },
      error: (err) => {
        console.error('Error fetching product data', err);
      }
    });
  }
}
