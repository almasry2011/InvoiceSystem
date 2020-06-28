using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int AvQuantity { get; set; }
        public ICollection<InvoiceDetailes> InvoiceDetailes { get; set; }

    }
}
