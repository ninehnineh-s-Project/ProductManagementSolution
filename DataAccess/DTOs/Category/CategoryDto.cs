using DataAccess.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Category
{
    public class CategoryDto : BaseDto, ICategoryDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

    }
}
