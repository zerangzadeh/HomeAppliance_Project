using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Management.Infrastruture.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
     public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(x=>x.ID);
            builder.Property(x=>x.Title).HasMaxLength(255).IsRequired();
            builder.Property(x=>x.Description).HasMaxLength(255);
            builder.Property(x => x.PicSrc).HasMaxLength(1000);
            builder.Property(x => x.PicTitle).HasMaxLength(255);
            builder.Property(x => x.PicAlt).HasMaxLength(255);
            builder.Property(x => x.KeyWord).HasMaxLength(80).IsRequired();
            builder.Property(x => x.MetaDesc).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();
           
        }
    }
}
