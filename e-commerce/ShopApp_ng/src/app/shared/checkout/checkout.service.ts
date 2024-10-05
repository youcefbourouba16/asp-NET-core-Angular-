import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { OrderViewModel } from '../../Models/OrderViewModel/orderviewmodel';

interface Country {
  name: {
    common: string;
  };
  // You can add more fields as needed
}

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  constructor(private http: HttpClient) {}

  private apiGetProductView = environment.apiUrl+'/Order';
  getCountries(): Observable<Country[]> {  
    const apiUrl = 'https://restcountries.com/v3.1/all';
    return this.http.get<Country[]>(apiUrl);
  }

  postOrder(order: OrderViewModel): Observable<any> {
    return this.http.post(`${this.apiGetProductView}/PlaceOrder`, order);
  }

  
}
