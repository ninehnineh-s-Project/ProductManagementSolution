using FluentValidation;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Product.Validator
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateProductDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            Include(new IProductDtoValidator(_categoryRepository));

            RuleFor(p => p.Description)
                .MaximumLength(200).WithMessage("{PropertyValue} must not exceed {ComparisonValue} characters.");
        }
    }
}
