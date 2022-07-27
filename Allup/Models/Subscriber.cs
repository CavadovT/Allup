using System.ComponentModel.DataAnnotations;

namespace Allup.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
     
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
