import { ContactComponent } from './Components/contact/contact.component';
import { ViewInvoiceComponent } from './Components/view-invoice/view-invoice.component';
import { CreateInvoiceComponent } from './Components/create-invoice/create-invoice.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  { path: "", component: CreateInvoiceComponent },
  { path: "invoice", component: CreateInvoiceComponent },
  { path: "invoice/:id", component: ViewInvoiceComponent },
  { path: "contact", component: ContactComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
