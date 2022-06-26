using BlogManagement.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategories
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public List<ArticleCategoryViewModel> articleCategoriesList { get; set; }
        public ArticleCategorySearchModel SearchModel { get; set; } 

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(ArticleCategorySearchModel SearchModel)
        {
            articleCategoriesList=_articleCategoryApplication.Search(SearchModel);

        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateArticleCategory());
        }

        public JsonResult OnPostCreate(CreateArticleCategory command)
        {
           var result=_articleCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetUpdate(long ID)
        {
            var articleCategory = _articleCategoryApplication.GetDetails(ID);
            return Partial("./Update", articleCategory);
        }

        public JsonResult OnPostUpdate(UpdateArticleCategory command)
        {
            if (ModelState.IsValid)
            {
            }
            var result = _articleCategoryApplication.Update(command);
            return new JsonResult(result);
        }
    }
}
