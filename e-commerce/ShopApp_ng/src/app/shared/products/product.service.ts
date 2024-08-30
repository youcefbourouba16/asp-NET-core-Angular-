import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductViewModel } from '../../Models/productViewModel/product-view-model';
import { Observable } from 'rxjs';
import { Color } from '../../Models/productViewModel/color_size/color';
import { Size } from '../../Models/productViewModel/color_size/size';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiGetProductView = 'http://localhost:5019/api/Product';

  constructor(private http: HttpClient){}
  getProductNamesAndPrices(): Observable<ProductViewModel[]> {
    return this.http.get<ProductViewModel[]>(`${this.apiGetProductView}/getProductView`);
  }

  getProductByID(ID : any) : Observable<any>{
    return this.http.get<ProductViewModel[]>(`${this.apiGetProductView}/getProductDetails/`+ID);
  }
  getColors(): Observable<Color[]> {
    return this.http.get<Color[]>(`${this.apiGetProductView}/getAllColors`);
  }
  getSizes(): Observable<Size[]> {
    return this.http.get<Size[]>(`${this.apiGetProductView}/getAllsize`);
  }
  

}
