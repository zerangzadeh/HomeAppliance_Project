using _01_HomeAppliance_Query.Contracts.Product;
using _01_HomeAppliance_Query.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {
        public string Value;
        public List<ProductQueryModel> Products;
        private readonly IProductQuery _productQuery;

        public SearchModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }
         
        public void OnGet(string value)
        {  
            Value=value.Trim(); 
            Products = _productQuery.Search(value);
        }
    }
}
