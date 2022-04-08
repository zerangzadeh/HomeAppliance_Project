

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
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Application;
using ShopManagement.Domain.SlideAgg;
using _01_HomeAppliance_Query.Query;
using _01_HomeAppliance_Query.Contracts.Slide;
using _01_HomeAppliance_Query.Contracts.ProductCategory;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootStrapper
    {

        public  static void Configure(IServiceCollection serviceCollection,string connectionString)
        {
            serviceCollection.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            serviceCollection.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            serviceCollection.AddTransient<IProductApplication, ProductApplication>();
            serviceCollection.AddTransient<IProductRepository, ProductRepository>();
            serviceCollection.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            serviceCollection.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            serviceCollection.AddTransient<ISlideApplication, SlideApplication>();
            serviceCollection.AddTransient<ISlideRepository, SlideRepository>();
            serviceCollection.AddTransient<ISlideQuery, SlideQuery>();
            serviceCollection.AddTransient<IProductCategoryQuery, ProductCategoryQuery>();
            serviceCollection.AddDbContext<ShopDBContext>(x => x.UseSqlServer(connectionString));
         }

    }
}