using _01_HA_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagment.Application.ProductCategory
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
            if (command != null)
            {
                if (_productCategoryRepository.Exists(x=>x.Title==command.Title))
                    return operationResult.Failed("رکورد تکراری");
                else
                {
                    var slug = command.Slug.GenerateSlug();
                    var productCategory = new ShopManagement.Domain.ProductCategoryAgg.ProductCategory(command.Title,
                        command.Description, command.PicSrc, command.PicAlt,command.PicTitle,
                        command.KeyWord, command.MetaDesc, slug);
                    _productCategoryRepository.Create(productCategory);
                    _productCategoryRepository.SaveChanges();
                    return operationResult.Succeeded("ذخیره موفقیت آمیز");
                }

            }

            else return operationResult.Failed("نقص اطلاعات");
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

        public ProductCategoryViewModel GetDetails(long ID)
        {
            _productCategoryRepository.GetDetails(ID);
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
                var productCategory = new ShopManagement.Domain.ProductCategoryAgg.ProductCategory(command.Title,
                           command.Description, command.PicSrc, command.PicAlt, command.PicTitle,
                           command.KeyWord, command.MetaDesc,slug);
                _productCategoryRepository.Update(productCategory);
                _productCategoryRepository.SaveChanges();
                return operationResult.Succeeded("ک.فق ");

            }
                    


        }
    }
}
