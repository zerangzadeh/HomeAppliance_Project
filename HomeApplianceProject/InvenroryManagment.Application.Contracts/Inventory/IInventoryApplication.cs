using _01_HA_Framework.Application;
using InventoryManagement.Application.Contracts.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contracts
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Update(UpdateInventory command);
        List<InventoryViewModel> GetAll();
        UpdateInventory GetDetails(long ID);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Reduce(List<ReduceInventory> command);
        OperationResult Reduce(ReduceInventory command);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);
    }
}
