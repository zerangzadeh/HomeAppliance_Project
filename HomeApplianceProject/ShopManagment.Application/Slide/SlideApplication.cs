using _0_Framework.Application;
using _01_HA_Framework.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.SlideAgg;
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
        private readonly IFileUploader _fileUploader;
        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            if (command != null)
            {
                var pictureName = _fileUploader.Upload(command.PictureSource, "slides");
                var slide = new ShopManagement.Domain.SlideAgg.Slide
                    (pictureName, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Title, command.Text, command.Link, command.BtnText);

                _slideRepository.Create(slide);

                return operationResult.Succeeded(messageForOperation.SuccessMessage);


            }

            return operationResult.Failed(messageForOperation.FailMessage);
        }

        public OperationResult Update(UpdateSlide command)
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
                var pictureName = _fileUploader.Upload(command.PictureSource, "slides");
                slide.Update(pictureName, command.PictureAlt,
                    command.PictureTitle, command.Heading, command.Title, command.Text,
                 command.Link, command.BtnText);
                _slideRepository.SaveChanges();
                return operationResult.Succeeded(messageForOperation.SuccessMessage);

            }

        }

        public OperationResult Remove(long ID)
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

        public OperationResult Restore(long ID)
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

        public UpdateSlide GetDetail(long ID)
        {
            return _slideRepository.GetDetails(ID);
        }

        public List<SlideViewModel> GetAll()
        {
            return _slideRepository.GetAll();
        }




    }
}
