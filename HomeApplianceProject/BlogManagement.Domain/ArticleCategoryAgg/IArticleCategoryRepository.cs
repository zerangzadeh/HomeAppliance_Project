
using _01_HA_Framework.Infrastructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using System.Collections.Generic;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IBaseRepository<long, ArticleCategory>
    {
        string GetSlugBy(long ID);
        UpdateArticleCategory GetDetails(long ID);
        List<ArticleCategoryViewModel> GetArticleCategories();
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
    }
}
