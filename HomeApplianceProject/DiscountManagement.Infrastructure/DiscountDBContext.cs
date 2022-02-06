using DiscountManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastruture.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure
{
    public class DiscountDBContext:DbContext
    {
        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
        
        public DiscountDBContext(DbContextOptions<DiscountDBContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CustomerDiscountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
            

        }
    }

}
}
