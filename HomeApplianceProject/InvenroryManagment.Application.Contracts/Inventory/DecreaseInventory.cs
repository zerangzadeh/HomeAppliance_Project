namespace InventoryManagement.Application.Contracts
{
    public class ReduceInventory
    {
        public long ProductID { get; set; }
        public long count { get; set; }
        public string Description { get; set; }
        public long OrderID { get; set; }



    }
}
