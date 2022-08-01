using System.ComponentModel.DataAnnotations;

namespace Allup.Models
{
    public class BasketProducts
    {
        public int Id { get; set; }
        [Required]

        public int BasketId { get; set; }
        public Basket Basket { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
