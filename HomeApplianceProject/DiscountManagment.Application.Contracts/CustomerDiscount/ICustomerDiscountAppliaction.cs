using _01_HA_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Create(CreateCustomerDiscount command);
        OperationResult Update(UpdateColleagueDiscount command);
        List<CustomerDiscountViewModel> GetAll();
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel customerDiscountSearchModel);
        UpdateColleagueDiscount GetDetails(long ID);

     


    }
}
