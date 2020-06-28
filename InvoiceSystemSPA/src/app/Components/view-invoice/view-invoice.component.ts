import { InvoiceModel } from './../../Interfaces/invoice-model';
import { Component, OnInit } from '@angular/core';
import { InvoiceService } from 'src/app/Services/invoice.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-view-invoice',
  templateUrl: './view-invoice.component.html',
  styleUrls: ['./view-invoice.component.css']
})
export class ViewInvoiceComponent implements OnInit {

  constructor(private InvoiceSrv: InvoiceService, private route: ActivatedRoute) { }
  InvoiceModel: InvoiceModel
  ngOnInit(): void {
    this.InvoiceSrv.GetInvoice(this.route.snapshot.params['id']).subscribe(
      res => {
        this.InvoiceModel = res
        console.log(this.InvoiceModel.invoiceDetailes)
      }
    )
  }

}
