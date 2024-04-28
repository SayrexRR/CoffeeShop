using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        [DefaultValue(1)]
        public int DisplayOrder { get; set; }

        public List<Product>? Products { get; set; }
    }
}
