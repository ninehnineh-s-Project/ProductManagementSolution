using DataAccess.DTOs.Category.Validators;
using FluentValidation;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Product.Validator
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateProductDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            Include(new IProductDtoValidator(_categoryRepository));
        }
    }
}
