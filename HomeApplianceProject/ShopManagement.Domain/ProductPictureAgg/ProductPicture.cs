using _01_HA_Framework;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public class ProductPicture : EntityBase<long>
    {
        public long ProductID { get; set; }
        public string PictureSource { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get; set; }
        public bool IsRemoved { get; set; }
        public Product Product { get; set; }

        public ProductPicture(long productID, string pictureSource, string pictureTitle, string pictureAlt)
           
        {
            ProductID = productID;
            PictureSource = pictureSource;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            IsRemoved = false;
        }

        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }

        public void Update(long productID, string pictureSource, string pictureTitle, string pictureAlt)
        { 
            ProductID = productID;
            PictureSource = pictureSource;
            PictureTitle = pictureTitle;
            PictureAlt = pictureAlt;
            IsRemoved = false;
        }

    }
}
