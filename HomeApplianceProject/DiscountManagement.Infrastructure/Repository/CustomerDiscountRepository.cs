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

namespace DiscountManagement.Infrastructure.Repository
{
    public class CustomerDiscountRepository : BaseRepository<long, CustomerDiscount>, ICustomerDiscountRepository
    {
        private readonly DiscountDBContext _discountDBContext;
        private readonly ShopDBContext _shopDBContext;

        public CustomerDiscountRepository(DiscountDBContext discountDBContext,ShopDBContext shopDBContext):base(discountDBContext)
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

        public UpdateCustomerDiscount GetDetails(long DiscountID)
        {

            return _discountDBContext.CustomerDiscounts.Select(x=>new UpdateCustomerDiscount { 
            ID=x.ID,
            ProductID=x.ProductID,
            DiscountRate=x.DiscountRate,
            StartDate=x.StartDate.ToString(),
            EndDate=x.EndDate.ToString(),
            Reason=x.Reason
            }).FirstOrDefault(x=>x.ID==DiscountID);
        }

       
        public List<CustomerDiscountViewModel> Search(ColleaueDiscountSearchModel searchModel)
        {
            var products=_shopDBContext.Products.Select(x=>new {x.ID , x.Name}).ToList();
            var query = _discountDBContext.CustomerDiscounts.Select(x => new CustomerDiscountViewModel {
                ID = x.ID,
                ProductID = x.ProductID,
                DiscountRate = x.DiscountRate,
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi(),
                StartDateGr = x.StartDate,
                EndDateGr = x.EndDate,
                Reason = x.Reason,
                CreationDate = x.CreationDate.ToFarsi()
            });
            if (searchModel.ProductID>0)
            {
                query.Where(x=>x.ProductID==searchModel.ProductID);
            }
            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
            {
                //var StartDate=DateTime.Now;
                query=query.Where(x=>x.StartDateGr>searchModel.StartDate.ToGeorgianDateTime());

            }
            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
            {
                //var EndDate = DateTime.Now;
                query = query.Where(x => x.EndDateGr > searchModel.EndDate.ToGeorgianDateTime());

            }

            var discounts = query.OrderByDescending(x => x.ID).ToList();
            discounts.ForEach(discount => 
                           discount.Product = products.FirstOrDefault(x => x.ID == discount.ProductID) ? .Name);

           return discounts;
        }

       
    }
}
