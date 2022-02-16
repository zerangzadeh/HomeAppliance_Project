using _01_HA_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Update(UpdateProduct command);
        void Delete(long ID);
        
        List<ProductViewModel> GetAll();
        List<ProductViewModel> GetProducts();
        UpdateProduct GetDetails(long ID);
        OperationResult SetIsStock(long ID);
        OperationResult SetNotInStock(long ID);
        List<ProductViewModel> Search(ProductSearchModel searchModel);
    }
}
