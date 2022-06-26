
using _0_Framework.Application;
using _01_HA_Framework.Application;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        public ArticleApplication(IArticleRepository articleRepository, IFileUploader fileUploader,
            IArticleCategoryRepository articleCategoryRepository)
        {
            _fileUploader = fileUploader;
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticle command)
        {
          
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            if (_articleRepository.Exists(x => x.Title == command.Title))
                return operationResult.Failed(messageForOperation.DoubleMessage);

            var slug = command.Slug.GenerateSlug();
            var categorySlug = _articleCategoryRepository.GetSlugBy(command.CategoryID);
            var path = $"{categorySlug}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();

            var article = new Article(command.Title, command.ShortDescription, command.Description, pictureName,
                command.PictureAlt, command.PictureTitle, publishDate, slug, command.Keywords, command.MetaDescription,
                command.CanonicalAddress, command.CategoryID);

            _articleRepository.Create(article);
            _articleRepository.SaveChanges();
            return operationResult.Succeeded(messageForOperation.SuccessMessage);
        }

        public OperationResult Update(UpdateArticle command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var article = _articleRepository.GetWithCategory(command.ID);

            if (article == null)
                return operationResult.Failed(messageForOperation.NotFoundMessage);

            if (_articleRepository.Exists(x => x.Title == command.Title && x.ID != command.ID))
                return operationResult.Failed(messageForOperation.ExistMessage);

            var slug = command.Slug.GenerateSlug();
            var path = $"{article.Category.Slug}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();

            article.Update(command.Title, command.ShortDescription, command.Description, pictureName,
                command.PictureAlt, command.PictureTitle, publishDate, slug, command.Keywords, command.MetaDescription,
                command.CanonicalAddress, command.CategoryID);

            _articleRepository.SaveChanges();
            return operationResult.Succeeded(messageForOperation.SuccessMessage);
        }

        public UpdateArticle GetDetails(long ID)
        {
            return _articleRepository.GetDetails(ID);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);
        }
    }
}
