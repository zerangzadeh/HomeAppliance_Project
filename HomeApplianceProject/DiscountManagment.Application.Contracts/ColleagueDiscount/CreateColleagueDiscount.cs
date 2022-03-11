
using ShopManagement.Application.Contracts.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public class CreateColleagueDiscount
    {
        public long ProductID { get; set; }
        public int  DiscountRate { get; set; }
        public List<ProductViewModel> Products { get; set; }
       
    }


}
