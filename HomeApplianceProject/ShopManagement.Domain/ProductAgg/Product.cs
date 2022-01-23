using _01_HA_Framework;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product:EntityBase<long>
    {
        public string Name { get;  set; }
        public string Code { get;  set; }
        public double  UnitPrice { get; set; }
        public bool  IsInStock { get; set; }
        public string ShortDESC { get;  set; }
        public string Description { get;  set; }
        public string PicSrc { get;  set; }
        public string PicAlt { get;  set; }
        public string PicTitle { get;  set; }
        public long CategoryId { get;  set; }
        public string Slug { get;  set; }
        public string Keywords { get;  set; }
        public string MetaDESC { get;  set; }
        public ProductCategory Category { get;  set; }
        public List<ProductPicture> Pictures { get; set; }

        public Product(string name, string code, double unitPrice, string shortDESC,
            string description, string picSrc, string picAlt, string picTitle,
            long categoryId, string slug, string keywords, string metaDESC)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDESC = shortDESC;
            IsInStock = true;
            Description = description;
            PicSrc = picSrc;
            PicAlt = picAlt;
            PicTitle = picTitle;
            CategoryId = categoryId;
            Slug = slug;
            Keywords = keywords;
            MetaDESC = metaDESC;
        }
    }
}
