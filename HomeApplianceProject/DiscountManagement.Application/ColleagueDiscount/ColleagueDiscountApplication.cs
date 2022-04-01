using _01_HA_Framework.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.ColleagueDiscount
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository _colleagueDiscountReporitory;

        public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountReporitory)
        {
            _colleagueDiscountReporitory = colleagueDiscountReporitory;
        }

        public OperationResult Create(CreateColleagueDiscount command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            if (_colleagueDiscountReporitory.Exists(x => x.ProductID == command.ProductID && x.DiscountRate == command.DiscountRate))
                return operationResult.Failed(messageForOperation.DoubleMessage);
            else
            {

                var colleagueDiscount = new DiscountManagement.Domain.ColleagueDiscountAgg.ColleagueDiscount(command.ProductID, command.DiscountRate);
                _colleagueDiscountReporitory.Create(colleagueDiscount);
                return operationResult.Succeeded(messageForOperation.SuccessMessage);
            }

        }

        public List<ColleagueDiscountViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Contract.ColleagueDiscount.UpdateColleagueDiscount GetDetails(long ID)
        {
           return _colleagueDiscountReporitory.GetDetails(ID);
        }

        public OperationResult Remove(long ID)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var colleagueDiscount = _colleagueDiscountReporitory.GetBy(ID);
            if (colleagueDiscount is null)
                return operationResult.Failed(messageForOperation.FailMessage);
            colleagueDiscount.Remove();
            
                _colleagueDiscountReporitory.SaveChanges();
                return operationResult.Succeeded(messageForOperation.SuccessMessage);
            
        }

        public OperationResult Restore(long ID)
        {

            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var colleagueDiscount = _colleagueDiscountReporitory.GetBy(ID);
            if (colleagueDiscount is null)
                return operationResult.Failed(messageForOperation.FailMessage);
            colleagueDiscount.Restore();

            _colleagueDiscountReporitory.SaveChanges();
            return operationResult.Succeeded(messageForOperation.SuccessMessage);
        }

        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel colleagueDiscountSearchModel)
        {
            return _colleagueDiscountReporitory.Search(colleagueDiscountSearchModel);
        }

        public OperationResult Update(Contract.ColleagueDiscount.UpdateColleagueDiscount command)
        {
            var operationResult = new OperationResult();
            var messageForOperation = new MessageForOpeartion();
            var colleagueDiscount = _colleagueDiscountReporitory.GetBy(command.ID);
            if (colleagueDiscount is null)
                return operationResult.Failed(messageForOperation.FailMessage);
            if (_colleagueDiscountReporitory.Exists(x => x.ProductID == command.ProductID && x.DiscountRate == command.DiscountRate && x.ID != command.ID))
                return operationResult.Failed(messageForOperation.DoubleMessage);
            else
            {

                colleagueDiscount.Update(command.ProductID, command.DiscountRate);
                _colleagueDiscountReporitory.SaveChanges();
                return operationResult.Succeeded(messageForOperation.SuccessMessage);
            }
        }
    }
    }

