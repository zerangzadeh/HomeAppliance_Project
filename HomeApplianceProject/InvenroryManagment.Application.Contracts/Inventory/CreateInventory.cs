using ShopManagement.Application.Contracts.Product;

namespace InventoryManagement.Application.Contracts
{
    public class CreateInventory
    {
        public long ProductID { get; set; }

        public double UnitPrice { get; set; }
        public List<ProductViewModel> Products { get; set; }

    }

}




