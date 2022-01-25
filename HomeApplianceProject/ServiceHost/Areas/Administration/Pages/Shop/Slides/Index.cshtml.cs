using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Application;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {
       
        string Message { get; set; }    
        
        public List<SlideViewModel> Slides;
      
        private readonly ISlideApplication _slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet()
        {
            Slides=_slideApplication.GetAll();
        }

        public IActionResult OnGetRemove(long ID)
        {
            var result = _slideApplication.Remove(ID);
            if (result.IsSucceeded)
                return RedirectToAction("Index");
            Message = result.Message;
            return RedirectToAction("Index");

        }

        public IActionResult OnGetRestore(long ID)
        {
            var result = _slideApplication.Restore(ID);
            if (result.IsSucceeded)
                return RedirectToAction("Index");
            Message = result.Message;
            return RedirectToAction("Index");
        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateSlide();
            return Partial("./Create", command);
        }


        public JsonResult OnPostCreate(CreateSlide command)
        {
            var result = _slideApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetUpdate(long id)
        {
            var slide = _slideApplication.GetDetail(id);    
            return Partial("Update", slide);
        }


        public IActionResult OnPostUpdate(UpdateSlide command)
        {
            var result = _slideApplication.Update(command);
            return new JsonResult(result);
                       
        }
    }
}