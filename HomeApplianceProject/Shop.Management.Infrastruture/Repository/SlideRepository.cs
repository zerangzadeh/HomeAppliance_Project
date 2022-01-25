using _01_HA_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop.Management.Infrastruture;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;

using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure.Repository
{
    public class SlideRepository : BaseRepository<long, Slide>, ISlideRepository
    {
        private readonly ShopDBContext _shopDBContext;

        public SlideRepository(ShopDBContext shopDBContext) : base(shopDBContext)
        {
            _shopDBContext = shopDBContext;
        }

       

        public List<SlideViewModel>  GetAll()
        {
           return _shopDBContext.Slides.Select
                (x => new SlideViewModel { 
                    ID=x.ID,
                    PictureSource=x.PictureSource,
                    Heading=x.Heading,
                    Title=x.Title,
                    IsRemoved=x.IsRemoved
                 }).OrderByDescending(x=>x.ID).ToList();
        }

        public UpdateSlide GetDetails(long ID)
        {
            return _shopDBContext.Slides.Select(x => new UpdateSlide
            {
                ID = x.ID,
                PictureSource = x.PictureSource,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                Heading = x.Heading,
                Title = x.Title,
                BtnText = x.BtnText,
            })
                   .FirstOrDefault(x => x.ID == ID);
        }

        
    }
}
