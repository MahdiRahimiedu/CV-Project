using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Services.Validators
{
    public class IServicDtoValidator : AbstractValidator<IServicDto>
    {
        public IServicDtoValidator()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("Fill in the name field")
                .MaximumLength(80).WithMessage("The length of the entered text is not correct");
        }
    }
}
