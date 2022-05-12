
using _01_HA_Framework.Application;
using _01_HA_Framework.Infrastructure;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Application.Contracts.Comment;
using System.Collections.Generic;
using System.Linq;
using CommentManagement.Infrastruture;

namespace CommentManagement.Infrastructure.Repository
{
    public class CommentRepository : BaseRepository<long, Comment>, ICommentRepository
    {
        private readonly CommentDBContext _commentDBContext;

        public CommentRepository(CommentDBContext context) : base(context)
        {
            _commentDBContext = context;
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            var query = _commentDBContext.Comments
                .Select(x => new CommentViewModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    Email = x.Email,
                    Website = x.Website,
                    Message = x.Message,
                    OwnerRecordId = x.OwnerRecordId,
                    Type = x.Type,
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
