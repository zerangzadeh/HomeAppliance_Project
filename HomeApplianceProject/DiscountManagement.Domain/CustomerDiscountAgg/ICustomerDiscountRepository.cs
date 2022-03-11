using _01_HA_Framework.Infrastructure;
using DiscountManagement.Application.Contract.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscountRepository:IBaseRepository<long,CustomerDiscount>
    {
        UpdateColleagueDiscount GetDetails(long DiscountID);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);

    }
}
