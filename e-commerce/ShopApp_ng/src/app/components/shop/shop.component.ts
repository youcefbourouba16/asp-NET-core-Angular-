import { AfterViewInit, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ProductViewModel } from '../../Models/productViewModel/product-view-model';
import { ProductService } from '../../shared/products/product.service';
import { Color } from '../../Models/productViewModel/color_size/color';
import { Router } from '@angular/router';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styles: ``
})
export class ShopComponent implements OnInit{
  products: ProductViewModel[] = [];
  colors : Color[]=[];
  selectedItems: string[] = [];
  isLoading: boolean = false;
  constructor(private productService: ProductService,private router: Router) { }
  ngOnInit(): void {
    this.router.events.subscribe(() => {
      this.loadProducts();
      this.loadColors();
    });
    
  }



  loadProducts(): void {
    this.isLoading = true;
    this.productService.getProductNamesAndPrices().subscribe({
      next: (data: ProductViewModel[]) => {
        console.log('Products loaded:', data);
        this.products = data;
        this.isLoading = false;
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
  loadProductByCategory(Category : string){
    this.productService.getProductsByCategory(Category).subscribe({
      next: (data: ProductViewModel[]) => {
        console.log('Products loaded:', data);
        this.products = data;
      },
      error: (err) => {
        console.error('Error fetching product data', err);
      }
    });
  }

  /*   Sizes section   */
  onCheckboxChange(event: Event, item: string) {
    const checkbox = event.target as HTMLInputElement;
    if (checkbox.checked) {
      this.selectedItems.push(item);
      this.loadProductBySizes(this.selectedItems);

    } else {
      this.selectedItems = this.selectedItems.filter(selectedItem => selectedItem !== item);
      this.loadProductBySizes(this.selectedItems)
    }
  }
  loadProductBySizes(sizes: string[]): void {
    this.productService.getProductBySizes(sizes).subscribe({
        next: (data: ProductViewModel[]) => {
            console.log('Products loaded:', data);
            this.products = data;
        },
        error: (err) => {
          this.products=[]
            console.error('Error fetching product data', err);
        }
    });
  }


  /*   Colors section   */
  loadProductByColor(color: string): void {
    this.productService.getProductsByColor(color).subscribe({
      next: (data: ProductViewModel[]) => {
        console.log('Products loaded:', data);
        this.products = data;
      },
      error: (err) => {
        this.products=[]
        console.error('Error fetching product data', err);
      }
    });
}
}
