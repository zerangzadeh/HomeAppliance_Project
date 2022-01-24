﻿using _01_HA_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        [Range(1,10000,ErrorMessage=ValidationMessages.IsRequired)]
        public long ProductID { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureSource { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }
        public List<ProductViewModel> Products { get; set; }

    }
}
