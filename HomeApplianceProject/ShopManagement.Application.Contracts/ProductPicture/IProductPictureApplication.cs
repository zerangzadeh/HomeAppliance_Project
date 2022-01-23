using _01_HA_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public interface IProductPictureApplication
    {
         OperationResult Create(CreateProductPicture createProductPicture);
         OperationResult Update(UpdateProductPicture updateProductPicture);
        OperationResult Remove(long ID);
        OperationResult Restore(long ID);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel productPictureSerachModel);
        UpdateProductPicture GetDetails(long ID);

    }
}
