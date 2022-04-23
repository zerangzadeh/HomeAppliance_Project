using _01_HomeAppliance_Query.Contracts.Product;
using _01_HomeAppliance_Query.Contracts.ProductCategory;
using _01_HomeAppliance_Query.Query;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LatestArrivalProductViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public LatestArrivalProductViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }


       

        public IViewComponentResult Invoke()
        {
            var products = _productQuery.GetLatestArrivals();
            return View("Default",products);
         
        }
    }
}