



using _01_HA_Framework.Application;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.Domain.CommentAgg;
using System.Collections.Generic;

namespace CommentManagement.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public OperationResult Add(AddComment command)
        {
            var operation = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            command.Website = "test.com";
            var comment = new Comment(command.Name, command.Email, command.Website, command.Message,
                command.OwnerRecordId, command.Type, command.ParentId);

            _commentRepository.Create(comment);
            _commentRepository.SaveChanges();
            return operation.Succeeded(messageForOperation.SuccessMessage);
        }

        public OperationResult Cancel(long id)
        {
            var operation = new OperationResult();
            var messageForOperation = new MessageForOpeartion();

            var comment = _commentRepository.GetBy(id);
            if (comment == null)
                return operation.Failed(messageForOperation.NotFoundMessage);

            comment.Cancel();
            _commentRepository.SaveChanges();
            return operation.Succeeded(messageForOperation.SuccessMessage);
        }

        public OperationResult Confirm(long id)
        {
            var operation = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var comment = _commentRepository.GetBy(id);
            if (comment == null)
                return operation.Failed(messageForOperation.NotFoundMessage);

            comment.Confirm();
            _commentRepository.SaveChanges();
            return operation.Succeeded(messageForOperation.SuccessMessage);
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            return _commentRepository.Search(searchModel);
        }

      

        
    }
}
