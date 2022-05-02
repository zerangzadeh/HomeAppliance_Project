using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HomeAppliance_Query.Contracts.Comment
{
    public class CommentQueryModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string CreationDate { get; set; }
        //public long ParentId { get; set; }
        //public string ParentName { get; set; }
    }
}
