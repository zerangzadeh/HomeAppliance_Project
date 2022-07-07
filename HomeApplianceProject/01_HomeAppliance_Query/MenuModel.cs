
using _01_HomeAppliance_Query.Contracts.ArticleCategory;
using _01_HomeAppliance_Query.Contracts.ProductCategory;
using System.Collections.Generic;

namespace _01_HomeAppliance_Query
{
    public class MenuModel
    {
        public List<ArticleCategoryQueryModel> ArticleCategories { get; set; }
        public List<ProductCategoryQueryModel> ProductCategories { get; set; }
    }
}
