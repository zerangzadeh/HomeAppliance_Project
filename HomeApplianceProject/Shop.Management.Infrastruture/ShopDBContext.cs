﻿using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastruture.Mapping;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Management.Infrastruture
{
    public class ShopDBContext:DbContext
    {
        public DbSet<ProductCategory> ProductCatrgories{ get; set; }

        public ShopDBContext(DbContextOptions<ShopDBContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
