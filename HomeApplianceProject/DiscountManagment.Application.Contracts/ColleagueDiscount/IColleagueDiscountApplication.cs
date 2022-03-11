using _01_HA_Framework.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OperationResult Create(CreateColleagueDiscount command);
        OperationResult Update(UpdateColleagueDiscount command);
        OperationResult Remove(long ID);
        OperationResult Restore(long ID);
        List<ColleagueDiscountViewModel> GetAll();
        List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel colleagueDiscountSearchModel);
        UpdateColleagueDiscount GetDetails(long ID);

     


    }
}
