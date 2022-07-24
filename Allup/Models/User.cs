using Microsoft.AspNetCore.Identity;

namespace Allup.Models
{
    public class User:IdentityUser
    {
        public string FullName { get; set; }
    }
}
