using _01_HA_Framework.Application;
using _01_HomeAppliance_Query.Contracts.Product;
using _01_HomeAppliance_Query.Contracts.ProductCategory;
using _01_HomeAppliance_Query.Contracts.Slide;
using DiscountManagement.Infrastructure;
using InventoryManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastruture;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HomeAppliance_Query.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopDBContext _shopDBContext;
        private readonly InventoryDBContext _inventoryDBContext;
        private readonly DiscountDBContext _discountDBContext;

        public ProductCategoryQuery(ShopDBContext shopDBContext, InventoryDBContext inventoryDBContext, DiscountDBContext discountDBContext)
        {
            _shopDBContext = shopDBContext;
            _inventoryDBContext = inventoryDBContext;
            _discountDBContext = discountDBContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _shopDBContext.ProductCatrgories.Select(x => new ProductCategoryQueryModel
            {
               ID = x.ID,
               Title = x.Title, 
               Description = x.Description,
               PicSrc = x.PicSrc,
               PicAlt = x.PicAlt,   
               PicTitle=x.PicTitle,
               MetaDesc=x.MetaDesc,
               KeyWord=x.KeyWord,
               Slug=x.Slug


            }).ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProducts()
        {
            var inventory = _inventoryDBContext.Inventory.Select(x =>
                 new { x.ProductID, x.UnitPrice }).ToList();
            var discounts = _discountDBContext.CustomerDiscounts
               .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
               .Select(x => new { x.DiscountRate, x.ProductID, x.EndDate }).ToList();

            var catetories = _shopDBContext.ProductCatrgories
                .Include(a => a.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    ID = x.ID,
                    Title = x.Title,
                    Description = x.Description,
                    MetaDesc = x.MetaDesc,
                     KeyWord = x.KeyWord,
                   
                    Slug = x.Slug,
                    Products = MapProducts(x.Products)
                }).ToList();
            foreach (var category in catetories)
            {
                foreach (var product in category.Products)
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
            }

            return catetories;
        }

        private static  List<ProductQueryModel> MapProducts(List<Product> products)
        {
            return products.Select(product => new ProductQueryModel
            {
                ID = product.ID,
                Category = product.Category.Title,
                Name = product.Name,
                PicSrc = product.PicSrc,
                PicAlt = product.PicAlt,
                PicTitle = product.PicTitle,
                Slug = product.Slug,
             }).ToList();

        }

        public ProductCategoryQueryModel GetProductCategoryWithProducstsBy(string slug)
        {
            var inventory = _inventoryDBContext.Inventory.Select(x =>
                 new { x.ProductID, x.UnitPrice }).ToList();
            var discounts = _discountDBContext.CustomerDiscounts
               .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
               .Select(x => new { x.DiscountRate, x.ProductID, x.EndDate }).ToList();

            var category = _shopDBContext.ProductCatrgories
                .Include(a => a.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    ID = x.ID,
                    Title = x.Title,
                    Description = x.Description,
                    MetaDesc = x.MetaDesc,
                    KeyWord = x.KeyWord,
                    Slug = x.Slug,
                    Products = MapProducts(x.Products)
                }).FirstOrDefault(x=>x.Slug==slug);
           
                foreach (var product in category.Products)
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
            

            return category;
        }
    }
}
