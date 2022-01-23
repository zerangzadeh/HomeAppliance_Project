using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class CreateProductPicture
    {
        public long ProductID { get; set; }
        public string PictureSource { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get; set; }
       
    }
}
