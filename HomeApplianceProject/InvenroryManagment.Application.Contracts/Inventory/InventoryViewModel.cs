namespace InventoryManagement.Application.Contracts
{
    public class InventoryViewModel
    {
        public long ID { get; set; }
        public string Product { get; set; }
        public long ProductID { get; set; }

        public double UnitPrice { get; set; }
        public bool  InStock { get; set; }
        public long  CurrentCount { get; set; }

    }

}




