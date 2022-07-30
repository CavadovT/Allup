using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Allup.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsBestSeller { get; set; }
        public bool IsNewArrivel { get; set; }
        public double Price { get; set; }
        public bool IsDelete { get; set; }
        public Nullable<double> DiscountPrice { get; set; }
        public Nullable<double> DiscountPercent { get; set; }
        public Nullable<double> TaxPercent { get; set; }
        [Required]

        public int Count { get; set; }

        public Nullable<DateTime> CreatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        [Required]

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public List<TagProducts> TagProducts { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        [NotMapped]
        public List<IFormFile> Photos { get; set; }
        [NotMapped]
        public List<int> TagIds { get; set; }

    }
}
