using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Task.Data;
using Task.Model;
using Task.Repositories.RepositorieBase;

namespace Task.Repositories
{
    public class InvoiceReopsitory : RepositorieBase<Invoice>, IInvoiceReopsitory
    {
        public InvoiceReopsitory(ApplicationDbContext context) :base(context)
        {}
        public async Task<InvoiveForReturnModel> GetInvoiceByID(int id)
        {
            var invoice = await db.Invoices
                 .Include(s => s.InvoiceDetailes).ThenInclude(s => s.product)
                 .SingleOrDefaultAsync(s => s.InvoiceId == id);

            if (invoice.InvoiceDetailes!=null)
            {
                IList<InvoiveDetailesForReturnModel> detailsModel = new List<InvoiveDetailesForReturnModel>();

                foreach (var detailes in invoice.InvoiceDetailes)
                {
                    detailsModel.Add( new InvoiveDetailesForReturnModel
                    {
                        ProductID = detailes.ProductID,
                        Description = detailes.product.Description,
                        ProductName = detailes.product.ProductName,
                        Quantity = detailes.Quantity,
                        UnitPrice = detailes.product.UnitPrice,
                         Total= detailes.product.UnitPrice * detailes.Quantity
                    });
                }


                var model = new InvoiveForReturnModel
                {
                    InvoiceDate = invoice.InvoiceDate,
                    InvoiceId = invoice.InvoiceId,
                    TotalInvoice = invoice.TotalInvoice,
                    invoiceDetailes = detailsModel
                };

                return model;

            }
            return null;
        }
    }
}
