using FluentValidation;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Product.Validator
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public IProductDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(30).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be after {ComparisonValue}.");

            RuleFor(p => p.CategoryId)
                .GreaterThan(0).WithMessage("{PropertyName} must be after {ComparisonValue}.")
                .MustAsync(async (id, token) =>
                {
                    var categoryExists = await _categoryRepository.Get(id);
                    if (categoryExists == null)
                        return false;
                    return true;
                }).WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.Supplier)
               .NotEmpty().WithMessage("{PropertyValue} is required.")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");
        }
    }
}
