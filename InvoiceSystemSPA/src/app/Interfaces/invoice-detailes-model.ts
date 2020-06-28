export interface InvoiceDetailesModel {
    productID: number;
    quantity: number;
    productName: string;
    description?: string;
    unitPrice?: number;
    total?: number;
}
