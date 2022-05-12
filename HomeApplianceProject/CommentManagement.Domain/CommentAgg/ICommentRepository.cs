
using _01_HA_Framework.Infrastructure;
using CommentManagement.Application.Contracts.Comment;

using System.Collections.Generic;

namespace CommentManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IBaseRepository<long, Comment>
    {
        List<CommentViewModel> Search(CommentSearchModel searchModel);
    }
}


