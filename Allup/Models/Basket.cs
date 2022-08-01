using System.Collections.Generic;

namespace Allup.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<BasketProducts> BasketProducts { get; set; }
    }
}
