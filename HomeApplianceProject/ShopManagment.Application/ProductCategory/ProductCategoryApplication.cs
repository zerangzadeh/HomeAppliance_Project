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

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
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
                    var productCategory = new ShopManagement.Domain.ProductCategoryAgg.ProductCategory(command.Title,
                        command.Description, command.PicSrc, command.PicAlt,command.PicTitle,
                        command.KeyWord, command.MetaDesc, slug);
                    _productCategoryRepository.Create(productCategory);
                  
                    return operationResult.Succeeded(messageForOperation.SuccessMessage);
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
                //To Fix

                productCategory.Title = command.Title;
                productCategory.Description = command.Description;
                productCategory.PicSrc = command.PicSrc;
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
