using _01_HA_Framework.Application;
using _01_HomeAppliance_Query.Contracts.Product;
using _01_HomeAppliance_Query.Contracts.ProductCategory;
using _01_LampshadeQuery.Contracts.Product;
using DiscountManagement.Infrastructure;
using InventoryManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastruture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
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

        public ProductQueryModel GetProductDetails(string slug)
        {
            var inventory = _inventoryDBContext.Inventory.Select(x => new { x.ProductID, x.UnitPrice, x.InStock }).ToList();

            var discounts = _discountDBContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductID, x.EndDate }).ToList();

            var product = _shopDBContext.Products
                .Include(x => x.Category)
                .Include(x => x.Pictures)
                .Select(x => new ProductQueryModel
                {
                    ID = x.ID,
                    Category = x.Category.Title,
                    Name = x.Name,
                    PicSrc = x.PicSrc,
                    PicAlt = x.PicAlt,
                    PicTitle = x.PicTitle,
                    Slug = x.Slug,
                    CategorySlug = x.Category.Slug,
                    Code = x.Code,
                    Description = x.Description,
                    Keywords = x.Keywords,
                    MetaDesc = x.MetaDESC,
                    ShortDesc = x.ShortDESC,
                    Pictures = MapProductPictures(x.Pictures)
                }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);

            if (product == null)
                return new ProductQueryModel();

            var productInventory = inventory.FirstOrDefault(x => x.ProductID == product.ID);
            if (productInventory != null)
            {
               // product. = productInventory.InStock;
                var price = productInventory.UnitPrice;
                product.Price = price.ToMoney();
                product.DoublePrice = price;
                var discount = discounts.FirstOrDefault(x => x.ProductID == product.ID);
                if (discount != null)
                {
                    var discountRate = discount.DiscountRate;
                    product.DiscountRate = discountRate;
                    product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                    product.HasDiscount = discountRate > 0;
                    var discountAmount = Math.Round((price * discountRate) / 100);
                    product.PriceWithDiscount = (price - discountAmount).ToMoney();
                }
            }

            //product.Comments = _commentContext.Comments
            //    .Where(x => !x.IsCanceled)
            //    .Where(x => x.IsConfirmed)
            //    .Where(x => x.Type == CommentType.Product)
            //    .Where(x => x.OwnerRecordId == product.Id)
            //    .Select(x => new CommentQueryModel
            //    {
            //        Id = x.Id,
            //        Message = x.Message,
            //        Name = x.Name,
            //        CreationDate = x.CreationDate.ToFarsi()
            //    }).OrderByDescending(x => x.Id).ToList();

            return product;
        }
        private static List<ProductPictureQueryModel> MapProductPictures(List<ProductPicture> pictures)
        {
            return pictures.Select(x => new ProductPictureQueryModel
            {
                IsRemoved = x.IsRemoved,
                PictureSource = x.PictureSource,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductID = x.ProductID
            }).Where(x => !x.IsRemoved).ToList();
        }





        public List<ProductQueryModel> Search(string value)
        {
            var inventory = _inventoryDBContext.Inventory.Select(x =>
                new { x.ProductID, x.UnitPrice }).ToList();
            var discounts = _discountDBContext.CustomerDiscounts
               .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
               .Select(x => new { x.DiscountRate, x.ProductID, x.EndDate }).ToList();

            var query = _shopDBContext.Products
                .Include(x => x.Category)
                .Select(x => new ProductQueryModel
                {
                    ID = x.ID,
                    Category = x.Category.Title,
                    CategorySlug = x.Category.Slug,
                    Name = x.Name,
                    PicSrc = x.PicSrc,
                    PicAlt = x.PicAlt,
                    PicTitle = x.PicTitle,
                    ShortDesc=x.ShortDESC,
                    Slug = x.Slug,

                }).AsNoTracking();
                 
                if (!string.IsNullOrEmpty(value))
                 {
                query = query.Where(x => x.Name.Contains(value) || x.ShortDesc.Contains(value));

                 }
                var products = query.OrderByDescending(x=>x.ID).ToList();

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
