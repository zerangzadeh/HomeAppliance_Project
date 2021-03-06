using _0_Framework.Application;
using _01_HA_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.ProductCategory
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateProductCategory command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            if (command != null)
            {
                if (_productCategoryRepository.Exists(x=>x.Title==command.Title))
                    return operationResult.Failed(messageForOperation.ExistMessage);
                else
                {
                    var slug = command.Slug.GenerateSlug();
                    var picturePath = $"{command.Slug}";
                    var pictureName = _fileUploader.Upload(command.PicSrc, picturePath);
                    var productCategory = new ShopManagement.Domain.ProductCategoryAgg.ProductCategory(command.Title,
                        command.Description, pictureName, command.PicAlt,command.PicTitle,
                        command.KeyWord, command.MetaDesc, slug);
                    _productCategoryRepository.Create(productCategory);
                  
                    return operationResult.Succeeded(messageForOperation.SuccessMessage);
                    var b = operationResult.IsSucceeded;
                }

            }

            else return operationResult.Failed(messageForOperation.FailMessage);
        }

        public void Delete(long ID)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductCategoryViewModel GetBy(long ID)
        {
            throw new NotImplementedException();
        }

        //public ProductCategoryViewModel GetBy(long ID)
        //{
        //    //return _productCategoryRepository.GetBy(ID);
        //}

        public UpdateProductCategory GetDetails(long ID)
        {
            return _productCategoryRepository.GetDetails(ID);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
           return _productCategoryRepository.GetProductCategories();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }

        public OperationResult Update(UpdateProductCategory command)
        {
            var operationResult = new OperationResult();
            var productCategory=_productCategoryRepository.GetBy(command.ID);
            if (productCategory == null)
            {
                return operationResult.Failed("یافت نشد");
            }
            if (_productCategoryRepository.Exists(x => x.Title == command.Title && x.ID != command.ID))
            {
                return operationResult.Failed("تکراری");
            }
            else
            {
                var slug = command.Slug.GenerateSlug();
                var picturePath = $"{command.Slug}"; 
                var filename = _fileUploader.Upload(command.PicSrc,picturePath);
              

                productCategory.Title = command.Title;
                productCategory.Description = command.Description;
                if (!string.IsNullOrWhiteSpace(command.PicSrc.FileName))
                      productCategory.PicSrc = filename;
                productCategory.PicAlt=command.PicAlt;
                productCategory.PicTitle=command.PicTitle;
                productCategory.KeyWord = command.KeyWord;
                productCategory.MetaDesc = command.MetaDesc;
                productCategory.Slug=command.Slug;


       _productCategoryRepository.Update(productCategory);
               
                return operationResult.Succeeded("ک.فق ");

            }
                    


        }
    }
}
