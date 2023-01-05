﻿using BusinessObject.Entity;
using DataAccess.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Product
{
    public class ProductDto : BaseDto, IProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Supplier { get; set; }
        public BusinessObject.Entity.Category Category { get; set; }

    }
}
