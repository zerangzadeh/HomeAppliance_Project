using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;


namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
       
        string Message { get; set; }    
        public ProductPictureSearchModel SearchModel { get; set; }
        public List<ProductPictureViewModel> ProductPictures;
        public SelectList Products;

        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductPictureApplication productPictureApplication,
            IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }

        
        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetAll(), "ID", "Name");
            ProductPictures = _productPictureApplication.Search(searchModel);
        }

        public IActionResult OnGetRemove(long ID)
        {
            var result = _productPictureApplication.Remove(ID);
            if (result.IsSucceeded)
                return RedirectToAction("Index");
            Message = result.Message;
            return RedirectToAction("Index");

        }

        public IActionResult OnGetRestore(long ID)
        {
            var result = _productPictureApplication.Restore(ID);
            if (result.IsSucceeded)
                return RedirectToAction("Index");
            Message = result.Message;
            return RedirectToAction("Index");
        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateProductPicture
            {
                Products = _productApplication.GetAll()
            };
            return Partial("./Create", command);
        }


        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var result = _productPictureApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetUpdate(long id)
        {
            var productPicture = _productPictureApplication.GetDetails(id);
            productPicture.Products = _productApplication.GetAll();
            return Partial("Update", productPicture);
        }


        public JsonResult OnPostUpdate(UpdateProductPicture command)
        {
            var result = _productPictureApplication.Update(command);
            return new JsonResult(result);
        }
    }
}