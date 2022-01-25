using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastruture.Mapping;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Management.Infrastruture
{
    public class ShopDBContext : DbContext
    {
        public DbSet<ProductCategory> ProductCatrgories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture>  ProductPictures{get; set;}
        public DbSet<Slide> Slides { get; set; }
        public ShopDBContext(DbContextOptions<ShopDBContext> options):base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
            assembly = typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
            assembly = typeof(SlideMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);

        }
    }
}
