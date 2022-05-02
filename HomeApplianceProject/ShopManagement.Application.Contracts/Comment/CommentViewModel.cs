﻿//namespace CommentManagement.Application.Contracts.Comment
namespace ShopManagement.Application.Contracts.Comment
{
    public class CommentViewModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Message { get; set; }
        //public long OwnerRecordId { get; set; }
        //public string OwnerName { get; set; }
        //public int Type { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCanceled { get; set; }
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string CommentDate { get; set; }
    }
}
