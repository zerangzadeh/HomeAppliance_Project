using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DiscountManagement.Application.Contract.CustomerDiscount;
using System.Collections.Generic;
using DiscountManagement.Application.CustomerDiscount;
using ShopManagement.Application.Product;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Discounts.CustomerDiscounts
{
    public class IndexModel : PageModel
    {
       
        string Message { get; set; }    
        public CustomerDiscountSearchModel SearchModel { get; set; }
        public List<CustomerDiscountViewModel> CustomerDiscounts;
        public SelectList Products;

        private readonly ICustomerDiscountApplication _customerDiscountApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(ICustomerDiscountApplication customerDiscountApplication,
                             IProductApplication productApplication)
        {
            _customerDiscountApplication = customerDiscountApplication;
            _productApplication = productApplication;
        }

        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "ID", "Name");
            CustomerDiscounts = _customerDiscountApplication.Search(searchModel);
        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateCustomerDiscount
            {

                Products = _productApplication.GetProducts()
            };
           
            return Partial("./Create",command);
        }

      
        public JsonResult OnPostCreate(CreateCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetUpdate(long id)
        {
            var customerDiscount = _customerDiscountApplication.GetDetails(id);
            customerDiscount.Products = _productApplication.GetProducts();
            return Partial("Update", customerDiscount );
        }

       
        public JsonResult OnPostUpdate(UpdateCustomerDiscount command)
        {
            var result = _customerDiscountApplication.Update(command);
            return new JsonResult(result);
        }
    }
}