using _01_HA_Framework.Application;
using ShopManagement.Application.Contracts.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide command);
        OperationResult Update(UpdateSlide command);
        OperationResult Remove(long ID);
        OperationResult Restore(long ID);
        UpdateSlide  GetDetail(long ID);
        List<SlideViewModel> GetAll();

    }
}
