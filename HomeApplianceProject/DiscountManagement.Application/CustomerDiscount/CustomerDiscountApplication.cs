using _01_HA_Framework.Application;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Application.Contract.CustomerDiscount;
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
           var operationResult=new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            if (_customerRepository.Exists(x => x.ProductID == command.ProductID && x.DiscountRate == command.DiscountRate))
                return operationResult.Failed(messageForOperation.DoubleMessage);
            else
            { 
                var Startdate=command.StartDate.ToGeorgianDateTime();
                var EndDate=command.EndDate.ToGeorgianDateTime();
                var customerDiscount= new DiscountManagement.Domain.CustomerDiscountAgg.CustomerDiscount(command.ProductID,command.DiscountRate,Startdate,EndDate,command.Reason);
                _customerRepository.Create(customerDiscount);
                return operationResult.Succeeded(messageForOperation.SuccessMessage);
            }
            

        }

        public List<CustomerDiscountViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UpdateCustomerDiscount GetDetails(long ID)
        {
          return  _customerRepository.GetDetails(ID);
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel customerDiscountSearchModel)
        {
            return _customerRepository.Search(customerDiscountSearchModel);
        }

        public OperationResult Update(UpdateCustomerDiscount command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var customerDiscount=_customerRepository.GetBy(command.ID);
            if (customerDiscount is null)
                return operationResult.Failed(messageForOperation.FailMessage);
            if (_customerRepository.Exists(x => x.ProductID == command.ProductID && x.DiscountRate == command.DiscountRate && x.ID!=command.ID))
                return operationResult.Failed(messageForOperation.DoubleMessage);
            else
            {
                var Startdate = command.StartDate.ToGeorgianDateTime();
                var EndDate = command.EndDate.ToGeorgianDateTime();
                customerDiscount.Update(command.ProductID, command.DiscountRate, Startdate, EndDate, command.Reason);
                   return operationResult.Succeeded(messageForOperation.SuccessMessage);
            }
        }
    }
}
