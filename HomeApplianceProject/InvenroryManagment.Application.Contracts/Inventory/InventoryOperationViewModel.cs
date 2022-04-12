namespace InventoryManagement.Application.Contracts.Inventory
{
    public class InventoryOperationViewModel
    {
        public long ID { get; set; }
        public bool OperationType { get; set; }
        public long Count { get; set; }
        public long OperatorID { get; set; }
        public string Operator { get; set; }
        public string OperationDate { get; set; }
        public long CurrentCount { get; set; }
        public string Description { get; set; }
        public long OrderID { get; set; }
    }
}
