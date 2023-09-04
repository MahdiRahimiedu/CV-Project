using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.ContactMes.Validators
{
    public class ChangeNoteContactMeDtoValidator: AbstractValidator<ChangeNoteContactMeDto>
    {
        public ChangeNoteContactMeDtoValidator()
        {
            RuleFor(o=>o.Note)
                .NotEmpty().WithMessage("Fill in the Note field")
                .NotNull().WithMessage("Fill in the Note field");
        }
    }
}
