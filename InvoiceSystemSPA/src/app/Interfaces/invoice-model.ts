import { InvoiceDetailesModel } from './invoice-detailes-model';
export interface InvoiceModel {
    invoiceId?: number;
    invoiceDate?: Date;
    totalInvoice?: number;
    invoiceDetailes?: InvoiceDetailesModel[];
}
