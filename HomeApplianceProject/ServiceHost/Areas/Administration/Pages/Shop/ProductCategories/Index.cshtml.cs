using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategoryApplication;
        public List<ProductCategoryViewModel> productCategoriesList { get; set; }
        public ProductCategorySearchModel categorySearchModel { get; set; } 

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductCategorySearchModel categorySearchModel)
        {
            productCategoriesList=_productCategoryApplication.Search(categorySearchModel);

        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory command)
        {
           var result=_productCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetUpdate(long ID)
        {
            var productCategory = _productCategoryApplication.GetDetails(ID);
            return Partial("./Update", productCategory);
        }

        public JsonResult OnPostUpdate(UpdateProductCategory command)
        {
            var result = _productCategoryApplication.Update(command);
            return new JsonResult(result);
        }
    }
}
