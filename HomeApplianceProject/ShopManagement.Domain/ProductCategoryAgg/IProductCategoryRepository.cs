using _01_HA_Framework.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository:IBaseRepository<long,ProductCategory>
    {
        UpdateProductCategory GetDetails(long ID);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
    }
}
