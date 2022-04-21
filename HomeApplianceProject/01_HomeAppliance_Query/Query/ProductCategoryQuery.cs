using _01_HomeAppliance_Query.Contracts.Product;
using _01_HomeAppliance_Query.Contracts.ProductCategory;
using _01_HomeAppliance_Query.Contracts.Slide;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastruture;
using ShopManagement.Domain.ProductAgg;
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


            }).Take(5).ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
        {
           return _shopDBContex.ProductCatrgories.Include(x=>x.Products).ThenInclude(x=>x.Category).
                Select(x=>new ProductCategoryQueryModel {
           
           ID = x.ID,
           Title=x.Title,
           Products = MapProducts(x.Products)
   
           }).ToList();
        }

        private static  List<ProductQueryModel> MapProducts(List<Product> products)
        {
            var result=new List<ProductQueryModel>();
            foreach (var product in products)
            {
                var item = new ProductQueryModel
                {
                    ID = product.ID,
                    Category = product.Category.Title,
                    Name = product.Name,
                    PicSrc = product.PicSrc,
                    PicAlt = product.PicAlt,
                    PicTitle = product.PicTitle,
                    Slug = product.Slug
                };
                result.Add(item);

            }
            return result;

           
        }
    }
}
