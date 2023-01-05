using BusinessObject.Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entity
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(30)]
        public string CategoryName { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public List<Product> Product { get; set; }
    }
}
