using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.Slide
{
    public class SlideViewModel
    {
        public long ID { get; set; }
        public string PictureSource { get; set; }
        public string Heading { get; set; }
        public string Title { get; set; }
        public bool IsRemoved { get; set; } 
    }
}
