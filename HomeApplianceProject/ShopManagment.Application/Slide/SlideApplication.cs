using _01_HA_Framework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository = slideRepository;
        }

        OperationResult Create(CreateSlide command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            if (command != null)
            {
                var slide = new ShopManagement.Domain.SlideAgg.Slide(command.PictureSource, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Title, command.Text,
                command.BtnText, command.Link);

                _slideRepository.Create(slide);

                return operationResult.Succeeded(messageForOperation.SuccessMessage);


            }

            return operationResult.Failed(messageForOperation.FailMessage);
        }

        OperationResult ISlideApplication.Update(UpdateSlide command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var slide = _slideRepository.GetBy(command.ID);
            if (slide == null)
            {
                return operationResult.Failed(messageForOperation.NotFoundMessage);
            }
           
            else
            {
                slide.Update(command.PictureSource, command.PictureAlt,
                    command.PictureTitle,command.Heading, command.Title, command.Text,
                 command.Link, command.BtnText);

                
                _slideRepository.SaveChanges();
                return operationResult.Succeeded(messageForOperation.SuccessMessage);

            }

        }

        OperationResult Remove(long ID)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var slide = _slideRepository.GetBy(ID);
            if (slide == null)
            {
                return operationResult.Failed(messageForOperation.NotFoundMessage);
            }

            slide.Remove();
            _slideRepository.SaveChanges();
            return operationResult.Succeeded(messageForOperation.SuccessMessage);
        }

        OperationResult Restore(long ID)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var slide = _slideRepository.GetBy(ID);
            if (slide == null)
            {
                return operationResult.Failed(messageForOperation.NotFoundMessage);
            }

            slide.Restore();
            _slideRepository.SaveChanges();
            return operationResult.Succeeded(messageForOperation.SuccessMessage);
        }

        UpdateSlide GetDetail(long ID)
        {
           return _slideRepository.GetDetails(ID);
        }

        List<SlideViewModel> GetAll()
        {
           return _slideRepository.GetAll();
        }
    }
}
