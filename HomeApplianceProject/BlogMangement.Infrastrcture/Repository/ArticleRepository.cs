using _0_Framework.Application;
using _01_HA_Framework.Application;
using _01_HA_Framework.Infrastructure;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Infrastructure.Repository
{
    public class ArticleRepository : BaseRepository<long, Article>, IArticleRepository
    {
        private readonly BlogDBContext _context;

        public ArticleRepository(BlogDBContext context) : base(context)
        {
            _context = context;
        }

        public UpdateArticle GetDetails(long ID)
        {
            return _context.Articles.Select(x => new UpdateArticle
            {
                ID = x.ID,
                CanonicalAddress = x.CanonicalAddress,
                CategoryID = x.CategoryID,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                Title = x.Title
            }).FirstOrDefault(x => x.ID == ID);
        }

        public Article GetWithCategory(long ID)
        {
            return _context.Articles.Include(x => x.Category).FirstOrDefault(x => x.ID == ID);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _context.Articles.Select(x => new ArticleViewModel
            {
                ID = x.ID,
                CategoryID = x.CategoryID,
                Category = x.Category.Name,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription.Substring(0, Math.Min(x.ShortDescription.Length, 50)) + " ...",
                Title = x.Title
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (searchModel.CategoryID > 0)
                query = query.Where(x => x.CategoryID == searchModel.CategoryID);

            return query.OrderByDescending(x => x.ID).ToList();
        }
    }
}
