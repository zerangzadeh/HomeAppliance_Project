namespace ShopManagement.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string PicSrc { get; set; }
        public string Category { get; set; }
        public long CategoryId { get; set; }
        public double UnitPrice { get; set; }   
        public string CreationDate { get; set; }
        public bool IsInStock { get; set; }
    }
}

