using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }

        [DefaultValue(1)]
        public int DisplayOrder { get; set; }
    }
}
