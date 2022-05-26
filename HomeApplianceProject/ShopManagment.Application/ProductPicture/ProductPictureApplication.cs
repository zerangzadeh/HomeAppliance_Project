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
using ShopManagement.Domain.ProductAgg;
using _0_Framework.Application;

namespace ShopManagement.Application.ProductPicture
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;

        public ProductPictureApplication(IProductPictureRepository productPicturRepository, IProductRepository productRepository, IFileUploader fileUploader)
        {
            _productPictureRepository = productPicturRepository;
            _productRepository = productRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var product = _productRepository.GetProductWithCategory(command.ProductID);
            var path = $"{product.Category.Slug}//{product.Slug}";
            var picturePath = _fileUploader.Upload(command.PictureSource, path);
            if (command != null)
            {
                  var productPicture =new ShopManagement.Domain.ProductPictureAgg.ProductPicture(
                      command.ProductID, picturePath, command.PictureTitle, command.PictureAlt);     
                  
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
            var productPicture = _productPictureRepository.GetWithProductAndCategory(command.ID);
            if (productPicture == null)
            {
                return operationResult.Failed(messageForOperation.NotFoundMessage);
            }
            //if (_productPictureRepository.Exists(x => x.PictureTitle == command.PictureTitle && x.ID != command.ID && x.ProductID!=command.ProductID))
            //{
            //    return operationResult.Failed(messageForOperation.ExistMessage);
            //}
           // else
            {
                // var product = _productRepository.GetProductWithCategory(command.ProductID);
                var path = $"{productPicture.Product.Category.Slug}//{productPicture.Product.Slug}";
                var picturePath = _fileUploader.Upload(command.PictureSource, path);
                productPicture.Update(command.ProductID,picturePath,command.PictureTitle,command.PictureAlt);
                _productPictureRepository.SaveChanges(); 
                return operationResult.Succeeded(messageForOperation.SuccessMessage);

            }

        }

        

     


     

     
      

   

    }
}
