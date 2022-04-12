using _01_HA_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Application.Contracts
{
    public class CreateInventory
    {
        [Range(1,100000,ErrorMessage=ValidationMessages.IsRequired)]
        public long ProductID { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = ValidationMessages.IsRequired)]
        public double UnitPrice { get; set; }
        public List<ProductViewModel> Products { get; set; }

    }

}




