using _01_HA_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get; set; }
       
        public string Description { get; set; }
     
        public string PicSrc { get; set; }
        public string PicAlt { get; set; }
        public string PicTitle { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string KeyWord { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDesc { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
    }

}