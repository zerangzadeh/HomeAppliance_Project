using _01_HA_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastruture;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Repository
{
    public class ProductRepository : BaseRepository<long, Product>, IProductRepository
    {
        private readonly ShopDBContext _shopDBContext;

        public ProductRepository(ShopDBContext shopDBContext) : base(shopDBContext)
        {
            _shopDBContext = shopDBContext;
        }

        public UpdateProduct GetDetails(long ID)
        {
            return _shopDBContext.Products.Select(x => new UpdateProduct
            {
                ID = x.ID,
                Name = x.Name,
                Code = x.Code,
                UnitPrice = x.UnitPrice,
                IsInStock = x.IsInStock,
                ShortDESC = x.ShortDESC,
                Description = x.Description,
                PicSrc = x.PicSrc,
                PicAlt = x.PicAlt,
                PicTitle = x.PicTitle,
                CategoryId = x.CategoryId,
                Slug = x.Slug,
                Keywords = x.Keywords,
                MetaDESC = x.MetaDESC
            }).FirstOrDefault(x => x.ID == ID);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _shopDBContext.Products.Include(x => x.Category)
                .Select(x => new ProductViewModel
                {

                    ID = x.ID,

                    Name = x.Name,
                    Code = x.Code,

                    PicSrc = x.PicSrc,
                    CategoryId=x.CategoryId,
                    Category = x.Category.Title, 
                    UnitPrice = x.UnitPrice,
                    CreationDate = x.CreationDate.ToString(),
                    IsInStock=x.IsInStock
                });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.CategoryId).ToList();

        }

        public void SetIsInStock(long ID)
        {
            _shopDBContext.Products.FirstOrDefault(x => x.ID == ID).IsInStock = true;
            _shopDBContext.SaveChanges();
        }

        public void SetNotInStock(long ID)
        {
            _shopDBContext.Products.FirstOrDefault(x => x.ID == ID).IsInStock = false;
            _shopDBContext.SaveChanges();
        }
    }
}
