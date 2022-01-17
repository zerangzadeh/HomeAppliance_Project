using _01_HA_Framework.Application;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    


namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory command);
        OperationResult Update(UpdateProductCategory command);
        void Delete(long ID);
        ProductCategoryViewModel GetBy(long ID);
        List<ProductCategoryViewModel> GetAll();
        UpdateProductCategory GetDetails(long ID);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
