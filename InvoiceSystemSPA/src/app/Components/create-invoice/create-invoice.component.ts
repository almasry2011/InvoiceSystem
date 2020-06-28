import { InvoiceService } from './../../Services/invoice.service';
import { InvoiceModel } from './../../Interfaces/invoice-model';
import { ProductService } from './../../Services/product.service';
import { Component, OnInit } from '@angular/core';
import { InvoiceDetailesModel } from 'src/app/Interfaces/invoice-detailes-model';
import { ProductModel } from 'src/app/Interfaces/product-model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-invoice',
  templateUrl: './create-invoice.component.html',
  styleUrls: ['./create-invoice.component.css']
})
export class CreateInvoiceComponent implements OnInit {

  constructor(private ProdSrv: ProductService, private InvoiceSrv: InvoiceService, private router: Router) { }
  InvoiceModel: Array<InvoiceDetailesModel> = [];
  ProductName: string = "";
  Qty: number = 0;
  IsInvalid: boolean = false;

  ProductsRes: ProductModel[];
  SelectedProduct: ProductModel;
  ngOnInit(): void {
    this.ProdSrv.GetAll().subscribe(
      res => {
        this.ProductsRes = res;
        console.log(res)
      });
  }

  Add() {
    console.log(this.SelectedProduct);
    var target = this.InvoiceModel.find(temp => temp.productID == this.SelectedProduct.productID)
    if (target) {
      target.quantity = this.Qty;
      target.total = this.Qty * this.SelectedProduct.unitPrice
      alert("Product already Added We Just Update The Quantity")
    }
    else {
      const model: InvoiceDetailesModel = {
        productID: this.SelectedProduct.productID,
        quantity: this.Qty,
        productName: this.SelectedProduct.productName,
        description: this.SelectedProduct.description,
        unitPrice: this.SelectedProduct.unitPrice,
        total: this.Qty * this.SelectedProduct.unitPrice
      };

      if (this.Qty > this.SelectedProduct.avQuantity) {
        alert("Error <=> Quantity Is Greater Than Available")
      } else {
        this.InvoiceModel.push(model)
        this.SelectedProduct = null;
        this.ProductName = ""
        console.log(this.InvoiceModel)
      }
    }
  }
  FindProduct() {
    this.ProdSrv.GetAll(this.ProductName).subscribe(
      res => {
        this.ProductsRes = res;
        console.log(res)
      }
    )
  }

  handleResultSelected(result) {
    console.log(result);
    this.SelectedProduct = result;
    this.ProductName = result.productName;
  }

  delete(prod: ProductModel) {
    var target = this.InvoiceModel.find(temp => temp.productID == prod.productID)
    if (target) {
      const index: number = this.InvoiceModel.indexOf(target);
      if (index !== -1) {
        this.InvoiceModel.splice(index, 1);
      }
    }
  }

  CreateInvoice() {
    const Createmodel: InvoiceModel = {
      invoiceDetailes: this.InvoiceModel
    }


    this.InvoiceSrv.CreateInvoice(Createmodel).subscribe(
      (res) => {
        console.log(res.message);
        alert(res.message)
        this.router.navigateByUrl(`/invoice/${res.invoiceId}`);
      },
      (err) => {
        alert(err.error)
      }
    )








  }

}
