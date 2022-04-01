using _01_HA_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagment.Domain.InventoryAgg
{
    public class Inventory:EntityBase<long>
    {
        public long ProductID { get; set; }
       
        public double UnitPrice { get; set; }
        public bool InStock { get; set; }
        public List<InventoryOperation> Operations { get; set; }

        public Inventory(long productID, double unitPrice)
        {
            ProductID = productID;
            UnitPrice = unitPrice;
            InStock =false;
           
        }
      public long CalculateCurrentCount()
        {
            var plus = Operations.Where(x => x.OperationType).Sum(x => x.Count);
            var minus = Operations.Where(x => !x.OperationType).Sum(x => x.Count);
            return plus - minus;
        }

        public void Increase(long count,long operatorID,string description)
        {
            var currentCount=CalculateCurrentCount()+count;
            var operation = new InventoryOperation(true, count, operatorID, currentCount, description, 0, ID);
            Operations.Add(operation);
            InStock = currentCount > 0;


        }

        public void Reduce(long count, long operatorID, string description,long orderID)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(false, count, operatorID, currentCount, description, 0, ID);
            Operations.Add(operation);
            InStock = currentCount > 0;


        }
    }

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

        public InventoryOperation(bool operationType, long count, long operationID, long currentCount, string description, long orederID, long inventoryID)
        {
            OperationType = operationType;
            Count = count;
            OperationID = operationID;
            CurrentCount = currentCount;
            Description = description;
            OrederID = orederID;
            InventoryID = inventoryID;
        }
    }
}
