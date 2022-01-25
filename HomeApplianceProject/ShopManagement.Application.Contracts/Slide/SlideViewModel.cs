using Microsoft.AspNetCore.Http;

namespace ShopManagement.Application.Contracts.Slide
{
    public class SlideViewModel
    {
        public long ID { get; set; }
        public IFormFile PictureSource { get; set; }
        public string Heading { get; set; }
        public string Title { get; set; }
    }
}
