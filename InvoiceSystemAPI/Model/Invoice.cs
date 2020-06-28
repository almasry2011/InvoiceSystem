using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Model
{
    public class Invoice
    {
        public Invoice()
        {
            InvoiceDate = DateTime.Now;
        }
        public int InvoiceId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalInvoice { get; set; }
        public ICollection<InvoiceDetailes> InvoiceDetailes { get; set; }
    }
}
