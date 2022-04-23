using _01_HA_Framework.Application;
using _01_HomeAppliance_Query.Contracts.Product;
using DiscountManagement.Infrastructure;
using InventoryManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastruture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HomeAppliance_Query.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopDBContext _shopDBContext;
        private readonly InventoryDBContext _inventoryDBContext;
        private readonly DiscountDBContext _discountDBContext;

        public ProductQuery(ShopDBContext shopDBContext, InventoryDBContext inventoryDBContext, DiscountDBContext discountDBContext)
        {
            _shopDBContext = shopDBContext;
            _inventoryDBContext = inventoryDBContext;
            _discountDBContext = discountDBContext;
        }

        public List<ProductQueryModel> GetLatestArrivals()
        {
            var inventory = _inventoryDBContext.Inventory.Select(x =>
                new { x.ProductID, x.UnitPrice }).ToList();
            var discounts = _discountDBContext.CustomerDiscounts
               .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
               .Select(x => new { x.DiscountRate, x.ProductID, x.EndDate }).ToList();



            var products = _shopDBContext.Products.Include(x => x.Category).Select(x => new ProductQueryModel {
                ID = x.ID,
                Category = x.Category.Title,
                Name = x.Name,
                PicSrc = x.PicSrc,
                PicAlt = x.PicAlt,
                PicTitle = x.PicTitle,
                Slug = x.Slug

            }).OrderByDescending(x=>x.ID).Take(6).ToList();

            foreach (var product in products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductID == product.ID);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();
                    var discount = discounts.FirstOrDefault(x => x.ProductID == product.ID);
                    if (discount != null)
                    {
                        int discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscount = (price - discountAmount).ToMoney();
                    }
                }
            }

            return products;
                

      
       

        }
    }
}
