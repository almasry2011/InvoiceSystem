using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Data;
using Task.Model;
using Task.Repositories.RepositorieBase;

namespace Task.Repositories
{
  public  interface IInvoiceReopsitory: IRepositorieBase<Invoice>
    {
        public  Task<InvoiveForReturnModel> GetInvoiceByID(int id);
    }
}
