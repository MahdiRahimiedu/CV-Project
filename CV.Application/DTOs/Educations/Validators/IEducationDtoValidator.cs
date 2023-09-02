using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Educations.Validators
{
    public class IEducationDtoValidator : AbstractValidator<IEducationDto>
    {
        public IEducationDtoValidator()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("Fill in the name field")
                .MaximumLength(50).WithMessage("The length of the entered text is not correct");

            RuleFor(o => o.Date).NotEmpty().WithMessage("Fill in the date field")
                .MaximumLength(50).WithMessage("The length of the entered text is not correct");

            RuleFor(o => o.Location).NotEmpty().WithMessage("Fill in the location field")
                .MaximumLength(150).WithMessage("The length of the entered text is not correct");


        }
    }
}
