using _01_HA_Framework.Infrastructure;
using ShopManagement.Application.Contracts.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.Slide
{
    public interface ISlideRepository:IBaseRepository<long,Slide>
    {
        UpdateSlide GetDetails(long ID);
        List<SlideViewModel> GetAll();
    }
}
