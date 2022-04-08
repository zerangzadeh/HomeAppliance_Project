using InventoryManagement.Application.Contracts;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure;
using InventoryManagement.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace InventoryManagement.Infrastructure.Configuration
{
    public class InventoryManagementBootStrapper
    {
        public static void Configure(IServiceCollection serviceCollection, String connectionString)
        {
          //  serviceCollection.AddTransient<IInventoryApplication, InventoryApplication>();
            serviceCollection.AddTransient<IInventoryRepository, InventoryRepository>();
         
            serviceCollection.AddDbContext<InventoryDBContext>(x => x.UseSqlServer(connectionString));
        }


    }
}



