using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HomeAppliance_Query.Contracts.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicSrc { get; set; }
        public string PicAlt { get; set; }
        public string PicTitle { get; set; }
        public string KeyWord { get; set; }
        public string MetaDesc { get; set; }
        public string Slug { get; set; }

    }
}
