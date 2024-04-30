using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Web.Mvc;

namespace DataAccess.ViewModels
{
    public class ProductViewModel
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

        public Guid CategoryId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
