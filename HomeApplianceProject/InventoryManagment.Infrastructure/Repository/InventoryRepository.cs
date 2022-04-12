using _01_HA_Framework.Application;
using _01_HA_Framework.Infrastructure;
using InventoryManagement.Application.Contracts;
using InventoryManagement.Application.Contracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure;
using Shop.Management.Infrastruture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Infrastructure.Repository
{
    public class InventoryRepository : BaseRepository<long, Inventory>,IInventoryRepository
    {
        private readonly InventoryDBContext _inventoryDBContext;
        private readonly ShopDBContext _shopDBContext;

        public InventoryRepository(InventoryDBContext inventoryDBContext, ShopDBContext shopDBContext) : base(inventoryDBContext)
        {
            _inventoryDBContext = inventoryDBContext;
            _shopDBContext = shopDBContext;
        }

        public UpdateInventory GetDetails(long ID)
        {
            return _inventoryDBContext.Inventory.Select(x => new UpdateInventory{ 
            ID=x.ID,
            ProductID=x.ProductID,
            UnitPrice=x.UnitPrice,
            
            }).FirstOrDefault(x => x.ID == ID);
            
        }

        public List<InventoryOperationViewModel> GetOperationLog(long inventoryID)
        {
            const int accountsID = 1;
            var inventory = _inventoryDBContext.Inventory.FirstOrDefault(x => x.ID == inventoryID);
            var operations = inventory.Operations.Select(x => new InventoryOperationViewModel
            {
                ID = x.ID,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                OperationType = x.OperationType,
                OperationDate = x.OperationDate.ToFarsi(),
                Operator="مدیر سیستم",
                OperatorID = x.OperatorID,
                OrderID = x.OrederID
                
            }).OrderByDescending(x => x.ID).ToList();

            //foreach (var operation in operations)
            //{
            //    operation.Operator = accounts.FirstOrDefault(x => x.Id == operation.OperatorId)?.Fullname;
            //}

            return operations;
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products=_shopDBContext.Products.Select(x => new { x.ID,x.Name}).ToList();
            var query = _inventoryDBContext.Inventory.Select(x => new InventoryViewModel { 
            ID=x.ID,
            UnitPrice=x.UnitPrice,
            InStock=x.InStock,
            ProductID = x.ProductID,
            CurrentCount=x.CalculateCurrentCount(),
            CreationDate=x.CreationDate.ToFarsi()
            });
            if (searchModel.ProductID>0)
            {
                query=query.Where(x=>x.ProductID==searchModel.ProductID);   
            }

            if (searchModel.InStock)
            {
                query = query.Where(x => !x.InStock);
            }
            var inventory=query.OrderByDescending(x=>x.ID).ToList();
            inventory.ForEach(item => { 
                item.Product = products.FirstOrDefault(x => x.ID == item.ProductID)?.Name;
                
            });
            return inventory;
            
        }

      

        List<InventoryViewModel> IInventoryRepository.GetAll()
        {
            throw new NotImplementedException();
        }

       
       
    }
}
