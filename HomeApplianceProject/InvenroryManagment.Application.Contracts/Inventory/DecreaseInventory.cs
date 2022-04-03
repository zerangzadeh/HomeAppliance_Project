namespace InvenroryManagment.Application.Contracts
{
    public class DecreaseInventory
    {
        public long ProductID { get; set; }
        public long count { get; set; }
        public string Description { get; set; }
        public long OrderID { get; set; }



    }
}
