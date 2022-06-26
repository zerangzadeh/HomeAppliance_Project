
using _0_Framework.Application;
using _01_HA_Framework.Application;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using System.Collections.Generic;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operation = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            if (_articleCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(messageForOperation.DoubleMessage);

            var slug = command.Slug.GenerateSlug();
            var pictureName = _fileUploader.Upload(command.Picture, slug);
            var articleCategory = new ArticleCategory(command.Name, pictureName, command.PictureAlt, command.PictureTitle
                , command.Description, command.ShowOrder, slug, command.Keywords, command.MetaDescription,
                command.CanonicalAddress);

            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.SaveChanges();
            return operation.Succeeded(messageForOperation.SuccessMessage);
        }

        public OperationResult Update(UpdateArticleCategory command)
        {
            var operation = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var articleCategory = _articleCategoryRepository.GetBy(command.ID);

            if (articleCategory == null)
                return operation.Failed(messageForOperation.FailMessage);

            if (_articleCategoryRepository.Exists(x => x.Name == command.Name && x.ID != command.ID))
                return operation.Failed(messageForOperation.DoubleMessage);

            var slug = command.Slug.GenerateSlug();
            var pictureName = _fileUploader.Upload(command.Picture, slug);
            articleCategory.Edit(command.Name, pictureName, command.PictureAlt, command.PictureTitle,
                command.Description, command.ShowOrder, slug, command.Keywords, command.MetaDescription,
                command.CanonicalAddress);

            _articleCategoryRepository.SaveChanges();
            return operation.Succeeded(messageForOperation.SuccessMessage);
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _articleCategoryRepository.GetArticleCategories();
        }

        public UpdateArticleCategory GetDetails(long ID)
        {
            return _articleCategoryRepository.GetDetails(ID);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            return _articleCategoryRepository.Search(searchModel);
        }

        
       
    }
}
