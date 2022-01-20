using _01_HA_Framework.Infrastructure;
using ShopManagement.Application.Contracts.Product;
//using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository:IBaseRepository<long,Product>
    {
        UpdateProduct GetDetails(long ID);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        public void SetNotInStock(long ID);
        public void SetIsInStock(long ID);
    }
}
