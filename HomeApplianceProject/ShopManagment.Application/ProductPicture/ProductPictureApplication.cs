using _01_HA_Framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;

namespace ShopManagement.Application.ProductPicture
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPicturRepository)
        {
            _productPictureRepository = productPicturRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            if (command != null)
            {
                  var productPicture =new ShopManagement.Domain.ProductPictureAgg.ProductPicture(command.ProductID, command.PictureSource, command.PictureTitle, command.PictureAlt);     
                  
                    _productPictureRepository.Create(productPicture);

                    return operationResult.Succeeded(messageForOperation.SuccessMessage);
            }

            else return operationResult.Failed(messageForOperation.FailMessage);
        }

        public UpdateProductPicture GetDetails(long ID)
        {
            return _productPictureRepository.GetDetails(ID);
        }

        public OperationResult Remove(long ID)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var productPicture = _productPictureRepository.GetBy(ID);
            if (productPicture == null)
            {
                return operationResult.Failed(messageForOperation.NotFoundMessage);
            }

            productPicture.Remove();
            _productPictureRepository.SaveChanges();
                return operationResult.Succeeded(messageForOperation.SuccessMessage);

           
        }

        public OperationResult Restore(long ID)
        {
        var operationResult = new OperationResult();
        var messageForOperation = new MessageForOpeartion();
        var productPicture = _productPictureRepository.GetBy(ID);
        if (productPicture == null)
        {
            return operationResult.Failed(messageForOperation.NotFoundMessage);
        }

        productPicture.Restore();
        _productPictureRepository.SaveChanges();
        return operationResult.Succeeded(messageForOperation.SuccessMessage);
  
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel productPictureSearchModel)
        {
            return _productPictureRepository.Search(productPictureSearchModel);

        }

        public OperationResult Update(UpdateProductPicture command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var productPicture = _productPictureRepository.GetBy(command.ID);
            if (productPicture == null)
            {
                return operationResult.Failed(messageForOperation.NotFoundMessage);
            }
            if (_productPictureRepository.Exists(x => x.PictureTitle == command.PictureTitle && x.ID != command.ID && x.ProductID!=command.ProductID))
            {
                return operationResult.Failed(messageForOperation.ExistMessage);
            }
            else
            {
                productPicture.Update(command.ProductID,command.PictureSource,command.PictureTitle,command.PictureAlt);
                _productPictureRepository.SaveChanges(); 
                return operationResult.Succeeded(messageForOperation.SuccessMessage);

            }

        }

        

     


     

     
      

   

    }
}
