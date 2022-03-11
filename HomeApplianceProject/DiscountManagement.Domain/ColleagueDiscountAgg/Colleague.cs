using _01_HA_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public class ColleagueDiscount:EntityBase<long>
    {
        public long ProductID { get; set; }
        public int DiscountRate { get; set; }
        public bool IsRemoved { get; set; }

        public ColleagueDiscount(long productID, int discountRate)
        {
            ProductID = productID;
            DiscountRate = discountRate;
            IsRemoved = false;
        }

        public ColleagueDiscount()
        {
        }

        public void Update(long productID, int discountRate)
        {
            ProductID = productID;
            DiscountRate = discountRate;
        }
        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
