using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Data;
using Task.Model;
using Task.Repositories;
using Task.Repositories.RepositorieBase;
 

namespace Task.UnitOfWorkConf
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        IRepositorieBase<Product> _ProductsRepo;
        IInvoiceReopsitory _InvoicesRepo;
        IRepositorieBase<InvoiceDetailes> _InvoiceDetailesRepo;
        public IRepositorieBase<Product> Products
        {
            get
            {
                if (_ProductsRepo == null)
                {
                    _ProductsRepo= new RepositorieBase<Product>(_context);
                }
                return _ProductsRepo;
            }
        }
        public IInvoiceReopsitory Invoices
        {
            get
            {
                if (_InvoicesRepo == null)
                {
                    _InvoicesRepo = new InvoiceReopsitory(_context);
                }
                return _InvoicesRepo;
            }
        }
        public IRepositorieBase<InvoiceDetailes> InvoiceDetailes 
        {
            get
            {
                if (_InvoiceDetailesRepo == null)
                {
                    _InvoiceDetailesRepo = new RepositorieBase<InvoiceDetailes>(_context);
                }
                return _InvoiceDetailesRepo;
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<bool> Save()
        {
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            return false;
        }
    }
}
