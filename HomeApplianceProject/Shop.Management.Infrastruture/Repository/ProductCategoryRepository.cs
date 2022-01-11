
using _01_HA_Framework.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Management.Infrastruture.Repository
{
    public class ProductCategoryRepository : BaseRepository<long, ProductCategory>, IProductCategoryRepository
    {
        private readonly ShopDBContext _shopDBContext;

        public ProductCategoryRepository(ShopDBContext shopDBContext)
        {
            _shopDBContext = shopDBContext;
        }

        public UpdateProductCategory GetDetails(long ID)
        {
           return _shopDBContext.ProductCatrgories.Select(x => new UpdateProductCategory
           { 
               ID = x.ID,
               Title = x.Title,
               Description = x.Description,
               PicSrc = x.PicSrc,
               PicAlt = x.PicAlt,
               PicTitle = x.PicTitle,
               KeyWord=x.KeyWord,
               MetaDesc=x.MetaDesc,
               Slug=x.Slug
            }).FirstOrDefault(x=>x.ID==ID);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _shopDBContext.ProductCatrgories.Select(x => new ProductCategoryViewModel
            {
                ID=x.ID,
                Title=x.Title,
                Description=x.Description,
                PicSrc=x.PicSrc,
                PicAlt=x.PicAlt,
                PicTitle=x.PicTitle,
                CreationDate=x.CreationDate.ToString(),
            });
            if (!String.IsNullOrEmpty(searchModel.Title))
            {
                query = query.Where(x => x.Title.Contains(searchModel.Title));
            }
            return query.OrderByDescending(x=>x.ID).ToList();
        }
    }
}
