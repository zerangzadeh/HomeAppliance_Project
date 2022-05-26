using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Management.Infrastruture.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.PictureSource).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PictureAlt).IsRequired();
           
            builder.HasOne(x => x.Product)
                .WithMany(x => x.Pictures)
                .HasForeignKey(x => x.ProductID);

          
        }

       
    }
}
