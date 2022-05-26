using _0_Framework.Application;
using _01_HA_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Product
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _fileUploader = fileUploader;
            _productCategoryRepository = productCategoryRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            if (command != null)
            {
                if (_productRepository.Exists(x => x.Name == command.Name))
                    return operationResult.Failed(messageForOperation.DoubleMessage);
                else
                {
                    var slug = command.Slug.GenerateSlug();
                    var categorySlug=_productCategoryRepository.GetSlugByID(command.CategoryId);
                    var path = $"{categorySlug}//{slug}";
                    var picturePath = _fileUploader.Upload(command.PicSrc, path);
                    var product = new ShopManagement.Domain.ProductAgg.Product(command.Name, command.Code, 
                command.ShortDESC, command.Description, picturePath ,
                command.PicAlt, command.PicTitle, command.CategoryId, slug,
                command.Keywords, command.MetaDESC);
                    _productRepository.Create(product);

                    return operationResult.Succeeded(messageForOperation.SuccessMessage);
                }

            }

            else return operationResult.Failed(messageForOperation.FailMessage);
        }


        public OperationResult Update(UpdateProduct command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var product = _productRepository.GetBy(command.ID);
            if (product == null)
            {
                return operationResult.Failed(messageForOperation.NotFoundMessage);
            }
            if (_productRepository.Exists(x => x.Name == command.Name && x.ID != command.ID))
            {
                return operationResult.Failed(messageForOperation.ExistMessage);
            }
            else
            {
                var slug = command.Slug.GenerateSlug();
                //To Fix
                var categorySlug = _productCategoryRepository.GetSlugByID(command.CategoryId);
                var path = $"{categorySlug}/{slug}";
                var picturePath = _fileUploader.Upload(command.PicSrc, path);
                product.Name = command.Name;
                product.Code = command.Code;
                
                product.ShortDESC = command.ShortDESC;
                product.Description = command.Description;
                if (!string.IsNullOrWhiteSpace(command.PicSrc.FileName))
                product.PicSrc = picturePath;
                product.PicAlt = command.PicAlt;
                product.PicTitle = command.PicTitle;
               
                product.CategoryId = command.CategoryId;
                product.Slug = slug;
                product.Keywords = command.Keywords;
                product.MetaDESC = command.MetaDESC;



                _productRepository.Update(product);

                return operationResult.Succeeded(messageForOperation.SuccessMessage);

            }



        }

        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> GetAll()
        {
            return _productRepository.GetAll();
        }


        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public UpdateProduct GetDetails(long ID)
        {
            return _productRepository.GetDetails(ID);
        }

        //public OperationResult SetIsStock(long ID)
        //{
        //    var operationResult = new OperationResult();
        //    var messageForOperation = new MessageForOpeartion();
        //    var product = _productRepository.GetBy(ID);
        //    if (product != null)
        //    {
        //        _productRepository.SetIsInStock(ID);
        //        return operationResult.Succeeded(messageForOperation.SuccessMessage);
        //    }


        //    else
        //    {
        //        return operationResult.Failed(messageForOperation.NotFoundMessage);
        //    }
        //}

        //public OperationResult SetNotInStock(long ID)
        //{
        //    var operationResult = new OperationResult();
        //    var messageForOperation = new MessageForOpeartion();
        //    var product = _productRepository.GetBy(ID);
        //    if (product != null)
        //    {
        //        _productRepository.SetNotInStock(ID);
        //        return operationResult.Succeeded(messageForOperation.SuccessMessage);

        //    }

        //    else
        //    {
        //        return operationResult.Failed(messageForOperation.NotFoundMessage);
        //    }
        //}

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }


    }
}
