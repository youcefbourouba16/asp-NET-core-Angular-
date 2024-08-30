import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ProductViewModel } from '../../Models/productViewModel/product-view-model';
import { ProductService } from '../../shared/products/product.service';
import { Color } from '../../Models/productViewModel/color_size/color';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styles: ``
})
export class ShopComponent implements OnInit{
  products: ProductViewModel[] = [];
  colors : Color[]=[];
  
  constructor(private productService: ProductService) { }
  ngOnInit(): void {
    this.loadProducts();
    this.loadColors();
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
  loadColors(): void{
    this.productService.getColors().subscribe({
      next: (data: Color[]) => {
        console.log('Products loaded:', data);
        this.colors = data;
      },
      error: (err) => {
        console.error('Error fetching product data', err);
      }
    });
  }
}
