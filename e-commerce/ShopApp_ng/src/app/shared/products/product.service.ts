import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ProductViewModel } from '../../Models/productViewModel/product-view-model';
import { Observable } from 'rxjs';
import { Color } from '../../Models/productViewModel/color_size/color';
import { Size } from '../../Models/productViewModel/color_size/size';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private apiGetProductView = environment.apiUrl+'/Product';

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
  
  getProductsByCategory(Category : any) : Observable<any>{
    return this.http.get<ProductViewModel[]>(`${this.apiGetProductView}/getProductByCategory/`+Category);
  }

  getProductBySizes(sizes: string[]): Observable<ProductViewModel[]> {
    let params = new HttpParams();
    sizes.forEach(size => {
        params = params.append('sizes', size);
    });
  
    return this.http.get<ProductViewModel[]>(`${this.apiGetProductView}/getProductBySizes/`, { params });
  }

  getProductsByColor(color: any): Observable<ProductViewModel[]> {
    return this.http.get<ProductViewModel[]>(`${this.apiGetProductView}/getProductByColor/`+color);
  }
  

}
