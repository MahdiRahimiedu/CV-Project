using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Projects.Validators
{
    public class IProjectDtoValidator : AbstractValidator<IProjectDto>
    {
        public IProjectDtoValidator()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("Fill in the name field")
                .MaximumLength(50).WithMessage("The length of the entered text is not correct");

            RuleFor(o => o.Applicant).NotEmpty().WithMessage("Fill in the applicant field")
                .MaximumLength(50).WithMessage("The length of the entered text is not correct");

            RuleFor(o => o.Date).NotEmpty().WithMessage("Fill in the date field")
                .MaximumLength(50).WithMessage("The length of the entered text is not correct");

            RuleFor(o => o.Img).NotNull().WithMessage("Fill in the image field");

        }
    }
}
