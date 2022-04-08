using _01_HA_Framework.Infrastructure;
using InventoryManagement.Application.Contracts;
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
        private readonly InventoryDBContext _inventoryDBContex;
        private readonly ShopDBContext _shopDBContext;

        public InventoryRepository(InventoryDBContext inventoryDBContex, ShopDBContext shopDBContext) : base(inventoryDBContex)
        {
            _inventoryDBContex = inventoryDBContex;
            _shopDBContext = shopDBContext;
        }

        public UpdateInventory GetDetails(long ID)
        {
            return _inventoryDBContex.Inventory.Select(x => new UpdateInventory{ 
            ID=x.ID,
            ProductID=x.ProductID,
            UnitPrice=x.UnitPrice,
            
            }).FirstOrDefault(x => x.ID == ID);
            
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products=_shopDBContext.Products.Select(x => new { x.ID,x.Name}).ToList();
            var query = _inventoryDBContex.Inventory.Select(x => new InventoryViewModel { 
            ID=x.ID,
            UnitPrice=x.UnitPrice,
            InStock=x.InStock,
            ProductID = x.ProductID,
            CurrentCount=x.CalculateCurrentCount()
            });
            if (searchModel.ProductID>0)
            {
                query=query.Where(x=>x.ProductID==searchModel.ProductID);   
            }

            if (!searchModel.InStock)
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
