
using _01_HA_Framework.Application;
using System.Collections.Generic;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Update(UpdateArticleCategory command);
        UpdateArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> GetArticleCategories();
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
    }
}
