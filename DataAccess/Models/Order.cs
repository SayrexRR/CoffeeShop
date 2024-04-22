using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string CustomerName { get; set; }

        [Required]
        public string CustomerAddress { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string CustomerPhone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? CustomerEmail { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
