import { ProductModel } from './../Interfaces/product-model';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private baseUrl: string = environment.apiUrl + 'products/';
  constructor(private http: HttpClient) { }

  GetAll(value?: string): Observable<ProductModel[]> {
    if (!value) { value = "" }
    return this.http.get<any>(this.baseUrl + `FinsProducts?value=${value}`);
  }
}
