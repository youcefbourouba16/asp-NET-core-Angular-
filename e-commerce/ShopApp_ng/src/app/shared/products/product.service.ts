import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductViewModel } from '../../Models/productViewModel/product-view-model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiGetProductView = 'http://localhost:5019/api/Product';

  constructor(private http: HttpClient){}
  getProductNamesAndPrices(): Observable<ProductViewModel[]> {
    return this.http.get<ProductViewModel[]>(`${this.apiGetProductView}/getProductView`);
  }
  

}
