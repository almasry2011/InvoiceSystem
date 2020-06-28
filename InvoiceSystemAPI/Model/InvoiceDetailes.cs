using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Model
{
    public class InvoiceDetailes
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }


        public int ProductID { get; set; }
        public Product product { get; set; }

        public int Quantity { get; set; }
        public decimal Total { get; set; }

    }
}
