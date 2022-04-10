using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InventoryManagement.Application.Contracts;
using System.Collections.Generic;
using InventoryManagement.Application;
using ShopManagement.Application.Product;
using ShopManagement.Application.Contracts.Product;
using InventoryManagement.Application.Contracts;
using InventoryManagement.Application.Contracts;

//using DiscountManagement.Application.ColleagueDiscount;
//using UpdateColleagueDiscount = DiscountManagement.Application.Contract.ColleagueDiscount.UpdateColleagueDiscount;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {
       [TempData]
        public string Message { get; set; }
        public InventorySearchModel SearchModel;
        public List<InventoryViewModel> Inventory;
        public SelectList Products;

        private readonly IInventoryApplication _inventoryApplication;
        private readonly IProductApplication _productApplication;

        public IndexModel(IInventoryApplication inventoryApplication,
                             IProductApplication productApplication)
        {
            _inventoryApplication = inventoryApplication;
            _productApplication = productApplication;
        }

        public void OnGet(InventorySearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "ID", "Name");
            Inventory = _inventoryApplication.Search(searchModel);
        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateInventory
            {

                Products = _productApplication.GetProducts()
            };
           
            return Partial("./Create",command);
        }

      
        public JsonResult OnPostCreate(CreateInventory command)
        {
            var result = _inventoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetUpdate(long id)
        {
            var inventory = _inventoryApplication.GetDetails(id);
            inventory.Products = _productApplication.GetProducts();
            return Partial("Update", inventory );
        }

       
        public JsonResult OnPostUpdate(UpdateInventory command)
        {
            var result = _inventoryApplication.Update(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetIncrease(long id)
        {
            var command = new IncreaseInventory()
            {
                InventoryID = id,

            };
           
            return Partial("Increase", command);
        }


        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var result = _inventoryApplication.Increase(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetReduce(long id)
        {
            var command = new ReduceInventory()
            {
                InventoryID = id,

            };

            return Partial("Reduce", command);
        }


        public JsonResult OnPostReduce(ReduceInventory command)
        {
            var result = _inventoryApplication.Reduce(command);
            return new JsonResult(result);
        }


    }
}