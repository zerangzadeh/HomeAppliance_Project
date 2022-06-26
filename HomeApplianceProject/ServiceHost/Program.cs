using ShopManagement.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DiscountManagement.Configuration;
using InventoryManagement.Infrastructure.Configuration;
using CommentManagement.Infrastructure.Configuration;
using _0_Framework.Application;
using ServiceHost;
using BlogManagement.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
ShopManagementBootStrapper.Configure(builder.Services, builder.Configuration.GetConnectionString("HomeApplianceDB"));
DiscountManagementBootStrapper.Configure(builder.Services, builder.Configuration.GetConnectionString("HomeApplianceDB"));
InventoryManagementBootStrapper.Configure(builder.Services, builder.Configuration.GetConnectionString("HomeApplianceDB"));
CommentManagementBootstrapper.Configure(builder.Services, builder.Configuration.GetConnectionString("HomeApplianceDB"));
BlogManagementBootstrapper.Configure(builder.Services, builder.Configuration.GetConnectionString("HomeApplianceDB"));

builder.Services.AddTransient<IFileUploader, FileUploader>();
var app = builder.Build();

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
//app.UseEndpoints(endpoints =>endpoints.MapDefaultControllerRoute());    


app.Run();
