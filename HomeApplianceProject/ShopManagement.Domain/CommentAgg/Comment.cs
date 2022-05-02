
using _01_HA_Framework;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.CommentAgg
{
    public class Comment : EntityBase<long>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Website { get; private set; }
        public string Message { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsCanceled { get; private set; }
        public long ProductID { get; set; }
        public Product Product { get; set; }
        //public long OwnerRecordId { get; private set; }
        //public int Type { get; private set; }
        //public long ParentId { get; private set; }
        //public Comment Parent { get; private set; }

        public Comment(string name, string email, string website, string message,long productID)
            //long ownerRecordId, int type, long parentId)
        {
            Name = name;
            Email = email;
            Website = website;
            Message = message;
            ProductID = productID;
            //OwnerRecordId = ownerRecordId;
            //Type = type;
            //ParentId = parentId;
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }

        public void Cancel()
        {
            IsCanceled = true;
        }
    }
}
