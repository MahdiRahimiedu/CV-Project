using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.SocialNetWorks.Validators
{
    public class ISocialNetWorkDtoValidator : AbstractValidator<ISocialNetWorkDto>
    {
        public ISocialNetWorkDtoValidator()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("Fill in the name field")
                .MaximumLength(50).WithMessage("The length of the entered text is not correct");

            RuleFor(o => o.Icon).NotNull().WithMessage("Fill in the icon field");

            RuleFor(o => o.Address).NotEmpty().WithMessage("Fill in the address field")
                .MaximumLength(150).WithMessage("The length of the entered text is not correct");
        }
    }
}
