using _01_HA_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagment.Application.Contract.CustomerDiscount
{
    public interface ICustomerDiscountAppliaction
    {
        OperationResult Create(CreateCustomerDiscount command);
        OperationResult Update(UpdateCustomerDiscount command);
        List<CustomerDiscountViewModel> GetAll();
     


    }
}
