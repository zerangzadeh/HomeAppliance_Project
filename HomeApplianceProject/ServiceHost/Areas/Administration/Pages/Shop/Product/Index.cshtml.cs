using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        public List<ProductViewModel> productsList { get; set; }
        public ProductSearchModel productSearchModel { get; set; } 
        public SelectList ProductCategories { get; set; }
        public IProductCategoryApplication ProductCategoryApplication { get; set; }

        public IndexModel(IProductApplication productApplication,IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            ProductCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductSearchModel productSearchModel)

        {
            ProductCategories=new SelectList(ProductCategoryApplication.GetProductCategories(),"ID","Title");
            productsList=_productApplication.Search(productSearchModel);

        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProduct());
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
           var result=_productApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetUpdate(long ID)
        {
            var productCategory = _productApplication.GetDetails(ID);
            return Partial("./Update", productCategory);
        }

        public JsonResult OnPostUpdate(UpdateProduct command)
        {
            var result = _productApplication.Update(command);
            return new JsonResult(result);
        }
    }
}
