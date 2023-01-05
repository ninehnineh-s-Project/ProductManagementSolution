using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Category.Validators
{
    public class DeleteCategoryDtoValidator : AbstractValidator<CategoryDto>
    {
        public DeleteCategoryDtoValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyValue} must be present.");
        }
    }
}
