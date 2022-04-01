using DiscountManagement.Application.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure;
using DiscountManagement.Infrastructure.Repository;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DiscountManagement.Application.Contract.ColleagueDiscount;
//using DiscountManagement.Application.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Application.ColleagueDiscount;

namespace DiscountManagement.Configuration
{
    public class DiscountManagementBootStrapper
    {
        public static void Configure(IServiceCollection serviceCollection,String connectionString)
        {
            serviceCollection.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            serviceCollection.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();
            serviceCollection.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();
            serviceCollection.AddTransient<IColleagueDiscountRepository, ColleagueDiscountRepository>();
            serviceCollection.AddDbContext<DiscountDBContext>(x => x.UseSqlServer(connectionString));
        }

    }
}