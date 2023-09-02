using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Skills.Validators
{
    public class EditSkillDtoValidator : AbstractValidator<EditSkillDto>
    {
        public EditSkillDtoValidator()
        {
            Include(new ISkillDtoValidator());
        }
    }
}
