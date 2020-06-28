import { InvoiceModel } from './../Interfaces/invoice-model';
import { InvoiceDetailesModel } from 'src/app/Interfaces/invoice-detailes-model';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  private baseUrl: string = environment.apiUrl + 'Invoices/';
  constructor(private http: HttpClient) { }

  CreateInvoice(InvoiceModel: InvoiceModel): Observable<any> {
    return this.http.post(this.baseUrl + 'CreateInvoice/', InvoiceModel);
  }

  GetInvoice(InvoiceId: number): Observable<InvoiceModel> {
    return this.http.get<InvoiceModel>(this.baseUrl + `GetInvoice?InvoiceId=${InvoiceId}`);
  }
}
