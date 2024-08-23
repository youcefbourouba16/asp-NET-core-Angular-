import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../shared/products/product.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styles: ``
})
export class DetailsComponent  implements OnInit{
  
  productId: number | undefined;
  product: any | undefined;

  constructor(private route: ActivatedRoute, productService : ProductService) {}

  ngOnInit() {
    this.productId = Number(this.route.snapshot.paramMap.get('id'));
    this.loadProductDetails();
  }

  loadProductDetails(){
    
  }

}
