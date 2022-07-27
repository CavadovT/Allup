using Allup.Models;
using System.Collections.Generic;

namespace Allup.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<SliderContent> SliderContents { get; set; }
        public List<Banner> Banners { get; set; }

        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<Brand> Brands { get; set; }
        public List<Blog> Blogs { get; set; }
        public Testonominal Testonominal { get; set; }

    }
}
