using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentSystemDaniel.Models
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        { 
        
        }

        public DbSet<Payments> Payments { get; set; }
        public DbSet<Balance> Balance { get; set; }
        public DbSet<TableHeaders> TableHeaders { get; set; }
    }
}
