using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Product.Validator
{
    public class DeleteProductDtoValidator : AbstractValidator<ProductDto>
    {
        public DeleteProductDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("{PropertyValue} must be present.");
        }
    }
}
