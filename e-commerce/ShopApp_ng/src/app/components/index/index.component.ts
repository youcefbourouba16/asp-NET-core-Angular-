import { Component, OnInit, AfterViewChecked } from '@angular/core';
import { ProductViewModel } from '../../Models/productViewModel/product-view-model';
import { ProductService } from '../../shared/products/product.service';
import { CartService } from '../../shared/Cart/cart.service';
import { Router } from '@angular/router';

declare var $: any;  // Declare jQuery

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styles: ``
})
export class IndexComponent implements OnInit, AfterViewChecked {

  products: ProductViewModel[] = [];
  carouselInitialized = false;
  isLoading: boolean = false;  

  constructor(private productService: ProductService,private router: Router) { }

  ngOnInit(): void {
    
    this.router.events.subscribe(() => {
      this.isLoading=true;
      this.productService.getProductNamesAndPrices().subscribe((data) => {
        this.products = data;
        console.log('Received data:', data);
        this.isLoading=false;
        
      });
    });
    
  }

  ngAfterViewChecked(): void {
    if (this.products.length > 0 && !this.carouselInitialized) {
      
      this.initializeCarousel();
      this.carouselInitialized = true;  // Prevent reinitialization
      
    }
  }

  initializeCarousel(): void {
    $('.nonloop-block-3').owlCarousel({
      center: false,
      items: 1,
      loop: false,
      stagePadding: 15,
      margin: 20,
      nav: true,
      navText: ['<span class="icon-arrow_back">', '<span class="icon-arrow_forward">'],
      responsive:{
        600:{
          margin: 20,
          items: 2
        },
        1000:{
          margin: 20,
          items: 3
        },
        1200:{
          margin: 20,
          items: 3
        }
      }
    });
  }
}