using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountManagement.Domain;
using DiscountManagement.Domain.ColleagueDiscountAgg;

namespace Shop.Management.Infrastruture.Mapping
{
    public class ColleagueDiscountMapping : IEntityTypeConfiguration<ColleagueDiscount>
    {
        public void Configure(EntityTypeBuilder<ColleagueDiscount> builder)
        {
            builder.ToTable("ColleagueDiscounts");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ProductID).IsRequired();
           
           //builder.HasOne(x => x.)
           //.WithMany(x => x.Products)
           //    .HasForeignKey(x => x.CategoryId);
           //builder.HasMany(x=>x.Pictures).WithOne(x => x.Product).HasForeignKey(x => x.ProductID);

        }
    }
}
