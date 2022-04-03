using _01_HA_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvenroryManagment.Application.Contracts
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Update(UpdateInventory command);
        List<InventoryViewModel> GetAll();
        UpdateInventory GetDetails(long ID);
        OperationResult Decrease(IncreaseInventory command);
        OperationResult Increase(List<DecreaseInventory> command);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
    }
}
