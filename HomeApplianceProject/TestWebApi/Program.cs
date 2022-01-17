using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastruture;
using Shop.Management.Infrastruture.Repository;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddControllers();
builder.Services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddDbContext<ShopDBContext>(x=>x.UseSqlServer("Data Source =.; Initial Catalog = HomeApplianceDB; Integrated Security = True"));
//var connectionString = builder.Configuration.GetConnectionString("HomeApplianceDB");
//builder.Services.AddDbContext<ShopDBContext>(x => x.UseSqlServer(connectionString));
var app = builder.Build();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "TodoApi", Version = "v1" });
//});



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
