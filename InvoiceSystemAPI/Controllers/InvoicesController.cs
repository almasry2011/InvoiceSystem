using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.Model;
using Task.UnitOfWorkConf;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public InvoicesController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpPost("CreateInvoice")]
        public async Task<IActionResult> CreateInvoice(Invoice invoiceModel)
        {
            if (invoiceModel.InvoiceDetailes != null)
            {
                foreach (var item in invoiceModel.InvoiceDetailes)
                {
                    var product =await _uow.Products.GetById(item.ProductID);
                    if (item.Quantity > product.AvQuantity)
                    {
                        return BadRequest("Error <=> Quantity Is Greater Than Available");
                    }
                    item.Total = item.Quantity * product.UnitPrice;
                    product.AvQuantity -= item.Quantity;
                    if (product.AvQuantity <= 0)
                    {
                        product.AvQuantity = 0;
                    }
                }
                invoiceModel.TotalInvoice = invoiceModel.InvoiceDetailes.Sum(s => s.Total);
               _uow.Invoices.Add(invoiceModel);
                if (await _uow.Save())
                    return Ok(new { Status= 1,InvoiceId=invoiceModel.InvoiceId,invoiceModel,Message= $"Invoice Created Successfully With Id {invoiceModel.InvoiceId}"});
            }
            return BadRequest();
        }

        [HttpGet("GetInvoice")]
        public async Task<IActionResult> GetInvoice(int InvoiceId)
        {
            if (InvoiceId > 0)
            {
                var invoice = await _uow.Invoices.GetInvoiceByID(InvoiceId);
               if (invoice != null)
                    return Ok(invoice);
               return NotFound("No Invoice For This Id");
            }
            return NotFound();
        }

    
    }
}
