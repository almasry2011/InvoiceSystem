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
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public ProductsController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        [HttpGet("FinsProducts")]
        public async Task<IActionResult> FinsProducts(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                var products = await _uow.Products.GetWhere(n => n.ProductName.Contains(value));
                if (products.Any())
                    return Ok(products);
                return NotFound("No Results Found");
            }
             return Ok(await _uow.Products.GetAll());
        }

    }
}
