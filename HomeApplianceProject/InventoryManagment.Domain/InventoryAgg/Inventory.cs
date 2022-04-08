using _01_HA_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
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
}
