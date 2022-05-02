using _01_HomeAppliance_Query.Contracts.Comment;
using _01_HomeAppliance_Query.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HomeAppliance_Query.Contracts.Product
{
    public class ProductQueryModel
    {
        public long ID { get; set; }
        public string PicSrc{ get; set; }
        public string PicAlt { get; set; }
        public string PicTitle { get; set; }
        public string Name { get; set; }
        public double DoublePrice { get; set; }
        public string Price { get; set; }
        public string PriceWithDiscount { get; set; }
        public int DiscountRate { get; set; }
        public string Category { get; set; }
        public string CategorySlug { get; set; }
        public bool HasDiscount { get; set; }
        public string DiscountExpireDate { get; set; }
        public string Code { get; set; }
        public string ShortDesc { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string MetaDesc { get; set; }
        public bool IsInStock { get; set; }
        public List<ProductPictureQueryModel> Pictures { get; set; }
        public List<CommentQueryModel> Comments { get; set; }

    }
}
