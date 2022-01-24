using _01_HA_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastruture;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Repository
{
    public class ProductPictureRepository : BaseRepository<long, ProductPicture>, IProductPictureRepository
    {
        private readonly ShopDBContext _shopDBContext;

        public ProductPictureRepository(ShopDBContext shopDBContext) : base(shopDBContext)
        {
            _shopDBContext = shopDBContext;
        }

      
        
        public List<ProductPictureViewModel> Search(ProductPictureSearchModel productPictureSearchModel)
        {
            var query = _shopDBContext.ProductPictures.Include(x => x.Product).
                   Select(x => new ProductPictureViewModel { 
                   ID=x.ID,
                   ProductName=x.Product.Name,
                   CreationDate=x.CreationDate.ToString(),
                   PictureSource=x.PictureSource,
                   ProductID=x.ProductID
                   });

            if (productPictureSearchModel.ProductID!=null || productPictureSearchModel.ProductID !=0)
                query = query.Where(x => x.ProductID== productPictureSearchModel.ProductID);

              return query.OrderByDescending(x => x.ID).ToList();

          
        }


        UpdateProductPicture IProductPictureRepository.GetDetails(long ID)
        {
            return _shopDBContext.ProductPictures.Select(x => new UpdateProductPicture
            {
                ID = x.ID,
                ProductID = x.ProductID,
                PictureSource = x.PictureSource,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt
            })
                   .FirstOrDefault(x => x.ID == ID);
        }
    }
}
