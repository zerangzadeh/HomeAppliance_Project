namespace InventoryManagement.Domain.InventoryAgg
{
    public class InventoryOperation
    {
        public long ID { get; set; }
        public bool OperationType { get; set; }
        public long Count { get; set; }
        public long OperatorID { get; set; }
        public DateTime OperationDate { get; set; }
        public long CurrentCount { get; set; }
        public string Description { get; set; }
        public long OrederID { get; set; }
        public long InventoryID   { get; set; }
        public Inventory Inventory { get; set; }

        public InventoryOperation()
        {
        }

        public InventoryOperation(bool operationType, long count, long operatorID,
            long currentCount, string description, long orederID, long inventoryID)
        {
            OperationType = operationType;
            Count = count;
            OperatorID = operatorID;
            CurrentCount = currentCount;
            Description = description;
            OrederID = orederID;
            InventoryID = inventoryID;
        }
    }
}
