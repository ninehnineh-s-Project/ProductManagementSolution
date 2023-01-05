using BusinessObject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "NutriBoost", Price = 50, CategoryId = 1, Description = "Just a Description", Supplier = "VN"},
                new Product { Id = 2, Name = "Pepsi", Price = 50, CategoryId = 1, Description = "Just a Description", Supplier = "VN" },
                new Product { Id = 3, Name = "Beef Rice Noodles", Price = 50, CategoryId = 2, Description = "Just a Description", Supplier = "VN" },
                new Product { Id = 4, Name = "Crab Rice Noodle", Price = 50, CategoryId = 2, Description = "Just a Description", Supplier = "VN" }
                );
        }
    }
}
