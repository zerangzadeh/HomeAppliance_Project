using _01_HA_Framework.Application;
using _01_HA_Framework.Infrastructure;
using DiscountManagement.Domain;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Application.Contract.CustomerDiscount;
using Shop.Management.Infrastruture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Application.Contract.ColleagueDiscount;

namespace DiscountManagement.Infrastructure.Repository
{
    public class ColleagueDiscountRepository : BaseRepository<long, ColleagueDiscount>, IColleagueDiscountRepository
    {
        private readonly DiscountDBContext _discountDBContext;
        private readonly ShopDBContext _shopDBContext;

        public ColleagueDiscountRepository(DiscountDBContext discountDBContext,ShopDBContext shopDBContext):base(discountDBContext)
        {
            _discountDBContext = discountDBContext;
            _shopDBContext = shopDBContext;
        }

        
        //public List<CustomerDiscount> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public CustomerDiscount GetBy(long ID)
        //{
        //    throw new NotImplementedException();
        //}

        public Application.Contract.ColleagueDiscount.UpdateColleagueDiscount GetDetails(long DiscountID)
        {

            return _discountDBContext.ColleagueDiscounts.Select(x=>new Application.Contract.ColleagueDiscount.UpdateColleagueDiscount
                {
                ID=x.ID,
                ProductID=x.ProductID,
                DiscountRate=x.DiscountRate

            }).FirstOrDefault(x=>x.ID==DiscountID);
        }


        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel searchModel)
        {
            var products=_shopDBContext.Products.Select(x=>new {x.ID , x.Name}).ToList();
            var query = _discountDBContext.ColleagueDiscounts.Select(x => new ColleagueDiscountViewModel {
                ID = x.ID,
                ProductID = x.ProductID,
                DiscountRate = x.DiscountRate,
                CreationDate = x.CreationDate.ToFarsi(),
                IsRemoved = x.IsRemoved
            });
            if (searchModel.ProductID>0)
            {
                query.Where(x=>x.ProductID==searchModel.ProductID);
            }
            

            var discounts = query.OrderByDescending(x => x.ID).ToList();
            discounts.ForEach(discount => 
                           discount.Product = products.FirstOrDefault(x => x.ID == discount.ProductID) ? .Name);

           return discounts;
        }

    
    }
}
