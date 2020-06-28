
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Model
{
    public class InvoiveForReturnModel
    {
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalInvoice { get; set; }
        public IEnumerable<InvoiveDetailesForReturnModel> invoiceDetailes { get; set; }
    }

    public class InvoiveDetailesForReturnModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }



}
