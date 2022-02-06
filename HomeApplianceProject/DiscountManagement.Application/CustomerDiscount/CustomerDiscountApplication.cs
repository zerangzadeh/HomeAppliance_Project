using _01_HA_Framework.Application;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagment.Application.Contract.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.CustomerDiscount
{
    public class CustomerDiscountApplication : ICustomerDiscountAppliaction
    {
        private readonly ICustomerDiscountRepository _customerRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public OperationResult Create(CreateCustomerDiscount command)
        {
            throw new NotImplementedException();
        }

        public List<CustomerDiscountViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(UpdateCustomerDiscount command)
        {
            throw new NotImplementedException();
        }
    }
}
