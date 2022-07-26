using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Allup.Models
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
        public List<Order> Orders { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
