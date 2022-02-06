namespace DiscountManagment.Application.Contract.CustomerDiscount
{
    public class CustomerDiscountSearchModel
    {
        public long ProductID { get; set; }
        public string Product { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
       
    }


}
