using DiscountManagement.Application.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure;
using DiscountManagement.Infrastructure.Repository;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Configuration
{
    public class DiscountManagementBootStrapper
    {
        public static void Configure(IServiceCollection serviceCollection,String connectionString)
        {
            serviceCollection.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            serviceCollection.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();
            serviceCollection.AddDbContext<DiscountDBContext>(x => x.UseSqlServer(connectionString));
        }

    }
}