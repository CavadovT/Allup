﻿using System.ComponentModel.DataAnnotations;

namespace Allup.Models
{
    public class OrderProducts
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
