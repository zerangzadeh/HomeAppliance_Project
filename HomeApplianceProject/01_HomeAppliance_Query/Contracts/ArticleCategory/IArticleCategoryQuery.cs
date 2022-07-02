using _01_HomeAppliance_Query.Contracts.ArticleCategory;
using System.Collections.Generic;

namespace _01_HomeAppliance_Query.Contracts.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        ArticleCategoryQueryModel GetArticleCategory(string slug);
        List<ArticleCategoryQueryModel> GetArticleCategories();
    }
}
