﻿namespace InventoryManagement.Application.Contracts
{
    public class ReduceInventory
    {
        public long InventoryID { get; set; }
        public long ProductID { get; set; }
        public long Count { get; set; }
        public string Description { get; set; }
        public long OrderID { get; set; }



    }
}
