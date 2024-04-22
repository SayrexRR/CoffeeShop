using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string ProductName { get; set; }

        [Required]
        [Range(0, 5000)]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        [DefaultValue(1)]
        public int DisplayOrder { get; set; }

        public string? ImageUrl { get; set; }

        public Category Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
