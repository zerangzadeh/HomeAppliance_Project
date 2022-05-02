
using _01_HA_Framework.Application;
using _01_HA_Framework.Infrastructure;

using ShopManagement.Application.Contracts.Comment;
//using CommentManagement.Domain.CommentAgg;
//using CommentManagement.Application.Contracts.Comment;
//using CommentManagement.Domain.CommentAgg;
using ShopManagement.Domain.CommentAgg;
using System.Collections.Generic;
using System.Linq;
using Shop.Management.Infrastruture;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class CommentRepository : BaseRepository<long, Comment>, ICommentRepository
    {
        private readonly ShopDBContext _shopDBContext;

        public CommentRepository(ShopDBContext context) : base(context)
        {
            _shopDBContext = context;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query = _shopDBContext.Comments
                .Select(x => new CommentViewModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    Email = x.Email,
                    Website = x.Website,
                    Message = x.Message,
                    //OwnerRecordId = x.OwnerRecordId,
                    //Type = x.Type,
                    IsCanceled = x.IsCanceled,
                    IsConfirmed = x.IsConfirmed,
                    CommentDate = x.CreationDate.ToFarsi()
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
                query = query.Where(x => x.Email.Contains(searchModel.Email));

            return query.OrderByDescending(x => x.ID).ToList();
        }

      
    }
}
