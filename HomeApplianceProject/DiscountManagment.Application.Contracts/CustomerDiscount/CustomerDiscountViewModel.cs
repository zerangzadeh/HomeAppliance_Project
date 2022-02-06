namespace DiscountManagment.Application.Contract.CustomerDiscount
{
    public class CustomerDiscountViewModel
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public string Product { get; set; }
        public int DiscountRate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime StartDateGr { get; set; }
        public DateTime EndDateGr { get; set; }
        public string Reason { get; set; }
    }


}
