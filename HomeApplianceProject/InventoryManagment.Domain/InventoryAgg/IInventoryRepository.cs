using _01_HA_Framework.Infrastructure;
using InventoryManagement.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository: IBaseRepository<long, Inventory>
    {
     
            UpdateInventory GetDetails(long ID);
            List<InventoryViewModel> GetAll();
             List<InventoryViewModel> Search(InventorySearchModel searchModel);

    }
}


