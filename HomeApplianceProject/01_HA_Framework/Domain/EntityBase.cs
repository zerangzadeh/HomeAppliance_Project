using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_HA_Framework
{
    public class EntityBase<TKey>
    {
        public TKey ID { get; set; }
        public DateTime CreationDate { get; set; }

        public EntityBase()
        {
        }

        public EntityBase(DateTime creationDate)
        {
            CreationDate = DateTime.Now;
        }
    }

}
