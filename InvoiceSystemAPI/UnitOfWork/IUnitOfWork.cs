using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Model;
using Task.Repositories;
using Task.Repositories.RepositorieBase;

namespace Task.UnitOfWorkConf
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositorieBase<Product> Products { get; }
        IInvoiceReopsitory Invoices { get; }
        IRepositorieBase<InvoiceDetailes> InvoiceDetailes { get; }
        Task<bool> Save();
    }
}
