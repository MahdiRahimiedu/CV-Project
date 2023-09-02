using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.EmploymentHistories.Validators
{
    public class IEmploymentHistoryDtoValidator : AbstractValidator<IEmploymentHistoryDto>
    {
        public IEmploymentHistoryDtoValidator()
        {
            RuleFor(o => o.Title).NotEmpty().WithMessage("Fill in the title field")
                .MaximumLength(50).WithMessage("The length of the entered text is not correct");

            RuleFor(o => o.Date).NotEmpty().WithMessage("Fill in the date field")
                .MaximumLength(100).WithMessage("The length of the entered text is not correct");

            RuleFor(o => o.Compony).NotEmpty().WithMessage("Fill in the compony field")
                .MaximumLength(150).WithMessage("The length of the entered text is not correct");
        }
    }
}
