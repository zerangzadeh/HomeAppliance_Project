namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class ColleagueDiscountViewModel
    {
        public long ID { get; set; }
        public long ProductID { get; set; }
        public string Product { get; set; }
        public int DiscountRate { get; set; }
        public bool  IsRemoved { get; set; }
        public string CreationDate { get; set; }
    }


}
