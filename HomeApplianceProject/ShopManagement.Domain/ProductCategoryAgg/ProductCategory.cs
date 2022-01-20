using _01_HA_Framework;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicSrc { get; set; }
        public string PicAlt { get; set; }
        public string PicTitle { get; set; }
        public string KeyWord { get; set; }
        public string MetaDesc { get; set; }
        public string Slug { get; set; }
        public List<Product> Products { get; set; } 

        public ProductCategory()
        {
            Products = new List<Product>();
        }

        public ProductCategory(string title, string description, string picSrc, string picAlt,
            string picTitle, string keyWord, string metaDesc, string slug)
        {
            Title = title;
            Description = description;
            PicSrc = picSrc;
            PicAlt = picAlt;
            PicTitle = picTitle;
            KeyWord = keyWord;
            MetaDesc = metaDesc;
            Slug = slug;
        }
    }
}
