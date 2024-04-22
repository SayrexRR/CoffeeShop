using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class OrderDetail
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }


    }
}
