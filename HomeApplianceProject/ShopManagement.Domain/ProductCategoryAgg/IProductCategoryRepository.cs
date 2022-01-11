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
        ProductCategoryViewModel GetDetails(long ID);
        List<ProductCategoryViewModel> Serach(ProductCategorySearchModel searchModel);
    }
}
