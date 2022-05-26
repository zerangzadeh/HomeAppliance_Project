using _01_HA_Framework.Infrastructure;
using ShopManagement.Application.Contracts.ProductPicture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository:IBaseRepository<long,ProductPicture>
    {
        List<ProductPictureViewModel> Search(ProductPictureSearchModel productPictureSearchModel);
        ProductPicture GetWithProductAndCategory(long ID);
        UpdateProductPicture GetDetails(long ID);

    }
}
