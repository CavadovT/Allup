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
        public string CompanyName { get; set; }
        public string Countr { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<OrderProducts> OrderProducts { get; set; }

    }
}
