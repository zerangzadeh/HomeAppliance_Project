
using _01_HA_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Code { get; set; }

        
        public string ShortDESC { get; set; }
        public string Description { get; set; }
        public string PicSrc { get; set; }
        public string PicAlt { get; set; }
        public string PicTitle { get; set; }
        [Range(1,1000000,ErrorMessage = ValidationMessages.IsRequired)]
        public long CategoryId { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDESC { get; set; }
        public List<ProductCategoryViewModel> Categories { get; set; }

    }
}

