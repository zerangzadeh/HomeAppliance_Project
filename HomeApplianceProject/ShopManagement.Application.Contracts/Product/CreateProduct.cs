using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double UnitPrice { get; set; }
        public bool IsInStock { get; set; }
        public string ShortDESC { get; set; }
        public string Description { get; set; }
        public string PicSrc { get; set; }
        public string PicAlt { get; set; }
        public string PicTitle { get; set; }
        public long CategoryId { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public string MetaDESC { get; set; }
       
    }
}

