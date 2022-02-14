using _01_HA_Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public class CustomerDiscount : EntityBase<long>
    {
        public long ProductID { get; set; }
        public int DiscountRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }

   
        public CustomerDiscount(long productID, int discountRate,
            DateTime startDate, DateTime endDate, string reason)
        {
            ProductID = productID;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
        }

        public void Update(long productID, int discountRate,
            DateTime startDate, DateTime endDate, string reason)
        {
            ProductID = productID;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;

        }
    }
}
