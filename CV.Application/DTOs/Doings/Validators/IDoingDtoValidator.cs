using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Doings.Validators
{
    public class IDoingDtoValidator : AbstractValidator<IDoingDto>
    {
        public IDoingDtoValidator()
        {
            RuleFor(o => o.Detail).NotEmpty().WithMessage("Fill in the detail field")
                .MaximumLength(150).WithMessage("The length of the entered text is not correct");

            RuleFor(o => o.Title).NotEmpty().WithMessage("Fill in the title field")
                .MaximumLength(50).WithMessage("The length of the entered text is not correct");

            RuleFor(o => o.Location).MaximumLength(150).WithMessage("The length of the entered text is not correct");
        }
    }
}
