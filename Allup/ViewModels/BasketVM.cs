using Allup.Models;
using System;

namespace Allup.ViewModels
{
    public class BasketVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductCount { get; set; }

        public string ImgUrl { get; set; }

        public int CategoryId { get; set; }
        
        public int BrandId { get; set; }
       
    }
}
