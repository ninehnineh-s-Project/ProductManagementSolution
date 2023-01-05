using FluentValidation;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs.Category.Validators
{
    public class UpdateCategoryDtoValidator : AbstractValidator<CategoryDto>
    {

        public UpdateCategoryDtoValidator()
        {
            Include(new ICategoryDtoValidator());

            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
