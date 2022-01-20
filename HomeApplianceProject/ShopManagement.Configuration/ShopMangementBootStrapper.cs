

using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Application.ProductCategory;
using Shop.Management.Infrastruture.Repository;
using Shop.Management.Infrastruture;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Infrastructure.Repository;
using ShopManagement.Application.Product;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Configuration
{
    public class ShopMangementBootStrapper
    {

        public  static void Configure(IServiceCollection serviceCollection,string connectionString)
        {
            serviceCollection.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            serviceCollection.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            serviceCollection.AddTransient<IProductApplication, ProductApplication>();
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            serviceCollection.AddDbContext<ShopDBContext>(x => x.UseSqlServer(connectionString));
         }

    }
}