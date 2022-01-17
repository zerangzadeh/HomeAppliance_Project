

using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Application.ProductCategory;
using Shop.Management.Infrastruture.Repository;
using Shop.Management.Infrastruture;
using Microsoft.EntityFrameworkCore;

namespace ShopManagement.Configuration
{
    public class ShopMangementBootStrapper
    {

        public  static void Configure(IServiceCollection serviceCollection,string connectionString)
        {
            serviceCollection.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            serviceCollection.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            serviceCollection.AddDbContext<ShopDBContext>(x => x.UseSqlServer(connectionString));
         }

    }
}