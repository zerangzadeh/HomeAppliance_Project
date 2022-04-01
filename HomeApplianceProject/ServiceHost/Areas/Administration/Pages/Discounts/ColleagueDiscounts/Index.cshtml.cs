using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using System.Collections.Generic;
using DiscountManagement.Application.ColleagueDiscount;
using ShopManagement.Application.Product;
using ShopManagement.Application.Contracts.Product;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
//using DiscountManagement.Application.ColleagueDiscount;
//using UpdateColleagueDiscount = DiscountManagement.Application.Contract.ColleagueDiscount.UpdateColleagueDiscount;

namespace ServiceHost.Areas.Administration.Pages.Discounts.ColleagueDiscounts
{
    public class IndexModel : PageModel
    {
       [TempData]
        public string Message { get; set; }
        public ColleagueDiscountSearchModel SearchModel;
        public List<ColleagueDiscountViewModel> ColleagueDiscounts;
        public SelectList Products;

        private readonly IColleagueDiscountApplication _colleagueDiscountApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IColleagueDiscountApplication colleagueDiscountApplication,
                             IProductApplication productApplication)
        {
            _colleagueDiscountApplication = colleagueDiscountApplication;
            _productApplication = productApplication;
        }

        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "ID", "Name");
            ColleagueDiscounts = _colleagueDiscountApplication.Search(searchModel);
        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateColleagueDiscount
            {

                Products = _productApplication.GetProducts()
            };
           
            return Partial("./Create",command);
        }

      
        public JsonResult OnPostCreate(CreateColleagueDiscount command)
        {
            var result = _colleagueDiscountApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetUpdate(long id)
        {
            var colleagueDiscount = _colleagueDiscountApplication.GetDetails(id);
            colleagueDiscount.Products = _productApplication.GetProducts();
            return Partial("Update", colleagueDiscount );
        }

       
        public JsonResult OnPostUpdate(UpdateColleagueDiscount command)
        {
            var result = _colleagueDiscountApplication.Update(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long ID)
        {
            _colleagueDiscountApplication.Remove(ID);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long ID)
        {
            _colleagueDiscountApplication.Restore(ID);
            return RedirectToPage("./Index");
        }
    }
}