using System;
using System.Collections.Generic;

namespace Allup.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<OrderItem> OrderItems { get; set; }

    }
}
