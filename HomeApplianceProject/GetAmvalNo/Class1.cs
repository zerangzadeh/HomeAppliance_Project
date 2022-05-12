using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GetAmvalNo
{
    public class AmvalDBContext : DbContext
    {
       
        public AmvalDBContext(DbContextOptions<AmvalDBContext> options) : base(options)
        {


        }
       
    }
    public class Class1
    {
        public static void Configure(IServiceCollection serviceCollection, String connectionString)
        {
               serviceCollection.AddDbContext<AmvalDBContext>(x => x.UseSqlServer(connectionString));
        }


    }
}