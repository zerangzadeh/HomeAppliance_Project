using _01_HomeAppliance_Query.Contracts.ProductCategory;
using _01_HomeAppliance_Query.Contracts.Slide;
using Shop.Management.Infrastruture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HomeAppliance_Query.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopDBContext _shopDBContex;

        public ProductCategoryQuery(ShopDBContext shopDBContex)
        {
            _shopDBContex = shopDBContex;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _shopDBContex.ProductCatrgories.Select(x => new ProductCategoryQueryModel
            {
               ID = x.ID,
               Title = x.Title, 
               Description = x.Description,
               PicSrc = x.PicSrc,
               PicAlt = x.PicAlt,   
               PicTitle=x.PicTitle,
               MetaDesc=x.MetaDesc,
               KeyWord=x.KeyWord,
               Slug=x.Slug


            }).ToList();
        }
    }
}
