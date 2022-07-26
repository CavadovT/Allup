using System.ComponentModel.DataAnnotations;

namespace Allup.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        public string Title { get; set; } = "Subscribe our newsletter";
        public string Desc { get; set; } = "allup is a powerful eCommerce HTML Template";
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
