

using _01_HA_Framework.Application;
using _01_HomeAppliance_Query.Contracts.Article;
using _01_HomeAppliance_Query.Contracts.Comment;
using BlogManagement.Infrastructure;
using CommentManagement.Infrastructure;
using CommentManagement.Infrastruture;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01_HomeAppliance_Query.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogDBContext _context;
        private readonly CommentDBContext _commentContext;

        public ArticleQuery(BlogDBContext context, CommentDBContext commentContext)
        {
            _context = context;
            _commentContext = commentContext;
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var article = _context.Articles
               .Include(x => x.Category)
               .Where(x => x.PublishDate <= DateTime.Now)
               .Select(x => new ArticleQueryModel
               {
                   ID = x.ID,
                   Title = x.Title,
                   CategoryName = x.Category.Name,
                   CategorySlug = x.Category.Slug,
                   Slug = x.Slug,
                   CanonicalAddress = x.CanonicalAddress,
                   Description = x.Description,
                   Keywords = x.Keywords,
                   MetaDescription = x.MetaDescription,
                   Picture = x.Picture,
                   PictureAlt = x.PictureAlt,
                   PictureTitle = x.PictureTitle,
                   PublishDate = x.PublishDate.ToFarsi(),
                   ShortDescription = x.ShortDescription,
               }).FirstOrDefault(x => x.Slug == slug);

            if (!string.IsNullOrWhiteSpace(article.Keywords))
                article.KeywordList = article.Keywords.Split(",").ToList();


            var comments = _commentContext.Comments
                .Where(x => !x.IsCanceled)
                .Where(x => x.IsConfirmed)
                .Where(x => x.Type == CommentType.Article)
                .Where(x => x.OwnerRecordId == article.ID)
                .Select(x => new CommentQueryModel
                {
                    ID = x.ID,
                    Message = x.Message,
                    Name = x.Name,
                    ParentID = x.ParentID,
                    CreationDate = x.CreationDate.ToFarsi()
                }).OrderByDescending(x => x.ID).ToList();

            foreach (var comment in comments)
            {
                if (comment.ParentID > 0)
                    comment.ParentName = comments.FirstOrDefault(x => x.ID == comment.ParentID)?.Name;
            }

            article.Comments = comments;

            return article;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
            return _context.Articles
                .Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Select(x => new ArticleQueryModel
                {
                    Title = x.Title,
                    Slug = x.Slug,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    PublishDate = x.PublishDate.ToFarsi(),
                    ShortDescription = x.ShortDescription,
                }).ToList();
        }
    }
}
