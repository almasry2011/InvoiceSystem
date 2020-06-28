using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Model;

namespace Task.Data
{
  
        public class ApplicationDbContext :  DbContext 
        {
            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                base.OnModelCreating(builder);
                builder.Entity<InvoiceDetailes>().HasKey(k => new { k.InvoiceId, k.ProductID });
            }
            public DbSet<Product> Products { get; set; }
            public DbSet<Invoice> Invoices { get; set; }
            public DbSet<InvoiceDetailes> InvoiceDetailes { get; set; }
    }

}
