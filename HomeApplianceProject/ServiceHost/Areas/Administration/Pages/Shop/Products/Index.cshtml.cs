using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;


namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
       
        string Message { get; set; }    
        public ProductSearchModel SearchModel { get; set; }
        public List<ProductViewModel> Products;
        public SelectList ProductCategories;

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public IndexModel(IProductApplication productApplication,
            IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        
        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "ID", "Title");
            Products = _productApplication.Search(searchModel);
        }

        public IActionResult OnGetNotInStock(long ID)
        {
            var result=_productApplication.SetNotInStock(ID);
            if (result.IsSucceeded)
                return RedirectToAction("Index");
            Message = result.Message;
            return RedirectToAction("Index");

        }

        public IActionResult OnGetIsInStock(long ID)
        {
            var result = _productApplication.SetIsStock(ID);
            if (result.IsSucceeded)
                return RedirectToAction("Index");
            Message = result.Message;
            return RedirectToAction("Index");
        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct
            {
                Categories = _productCategoryApplication.GetProductCategories()
            };
            return Partial("./Create", command);
        }

      
        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetUpdate(long id)
        {
            var product = _productApplication.GetDetails(id);
            product.Categories = _productCategoryApplication.GetProductCategories();
            return Partial("Update", product);
        }

       
        public JsonResult OnPostUpdate(UpdateProduct command)
        {
            var result = _productApplication.Update(command);
            return new JsonResult(result);
        }
    }
}