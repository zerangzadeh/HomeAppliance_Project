
using _01_HA_Framework.Application;
using _01_HA_Framework.Infrastructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Infrastructure.Repository
{
    public class ArticleCategoryRepository : BaseRepository<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogDBContext _blogDbContext;

        public ArticleCategoryRepository(BlogDBContext context) : base(context)
        {
            _blogDbContext = context;
        }

        public List<ArticleCategoryViewModel> GetArticleCategories()
        {
            return _blogDbContext.ArticleCategories.Select(x => new ArticleCategoryViewModel
            {
                ID = x.ID,
                Name = x.Name
            }).ToList();
        }

        public UpdateArticleCategory GetDetails(long ID)
        {
            return _blogDbContext.ArticleCategories.Select(x => new UpdateArticleCategory
            {
                ID = x.ID,
                Name = x.Name,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.ID == ID);
        }

        public string GetSlugBy(long id)
        {
            return _blogDbContext.ArticleCategories.Select(x => new { x.ID, x.Slug })
                .FirstOrDefault(x => x.ID == id).Slug;
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            var query = _blogDbContext.ArticleCategories
                .Include(x => x.Articles)
                .Select(x => new ArticleCategoryViewModel
                {
                    ID = x.ID,
                    Description = x.Description,
                    Name = x.Name,
                    Picture = x.Picture,
                    ShowOrder = x.ShowOrder,
                    CreationDate = x.CreationDate.ToFarsi(),
                    ArticlesCount = x.Articles.Count
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.ShowOrder).ToList();
        }
    }
}
