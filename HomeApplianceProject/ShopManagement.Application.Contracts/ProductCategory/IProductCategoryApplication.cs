using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    


namespace ShopManagement.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        void Create(CreateProductCategory command);
        void Update(UpdateProductCategory command);
        void Delete(long ID);
        ProductCategoryViewModel GetBy(long ID);
        List<ProductCategoryViewModel> GetAll();
        ProductCategoryViewModel GetDetails(long ID);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);




    }
}
