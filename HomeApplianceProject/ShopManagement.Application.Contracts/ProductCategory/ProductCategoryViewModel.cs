namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public long ID { get; set; }    
        public string Title { get; set; }
        public string Description { get; set; }
        public string PicSrc { get; set; }
        public string PicAlt { get; set; }
        public string PicTitle { get; set; }
        public string CreationDate { get; set; }
        public long ProductCount  { get; set; }

    }

}