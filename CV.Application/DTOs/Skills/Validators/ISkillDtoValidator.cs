using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Skills.Validators
{
    public class ISkillDtoValidator : AbstractValidator<ISkillDto>
    {
        public ISkillDtoValidator()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("Fill in the name field")
                .MaximumLength(50).WithMessage("The length of the entered text is not correct");

            RuleFor(o => o.SkillValue).NotEmpty().WithMessage("Fill in the skill value field")
                .MaximumLength(70).WithMessage("The length of the entered text is not correct");
        }
    }
}
