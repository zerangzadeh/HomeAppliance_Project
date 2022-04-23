using _01_HomeAppliance_Query.Contracts.Slide;
using Shop.Management.Infrastruture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HomeAppliance_Query.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopDBContext _shopDBContex;

        public SlideQuery(ShopDBContext shopDBContex)
        {
            _shopDBContex = shopDBContex;
        }

        public List<SlideQueryModel> GetSlides()
        {
            return _shopDBContex.Slides.Where(x => x.IsRemoved == false).Select(x => new SlideQueryModel
            {
                PictureSource = x.PictureSource,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Heading = x.Heading,
                Title = x.Title,
                Text = x.Text,
                BtnText = x.BtnText,
                Link = x.Link
            }).ToList();
        }
    }
}
