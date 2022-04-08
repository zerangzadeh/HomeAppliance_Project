using InventoryManagement.Domain.InventoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Mappings
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
           builder.ToTable("Inventory");
           builder.HasKey(x=>x.ID);
            builder.OwnsMany(x => x.Operations, modelBuilder => {
                modelBuilder.HasKey(x => x.ID);
                modelBuilder.ToTable("InventoryOperations");
                modelBuilder.Property(x => x.Description).HasMaxLength(500);
                modelBuilder.WithOwner(x =>x.Inventory).HasForeignKey(x => x.InventoryID);


            });

        }
    }
}
