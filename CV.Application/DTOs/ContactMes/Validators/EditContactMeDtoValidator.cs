using CV.Application.DTOs.Doings.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.ContactMes.Validators
{
    public class EditContactMeDtoValidator : AbstractValidator<EditContactMeDto>
    {
        public EditContactMeDtoValidator()
        {
            Include(new IContactMeDtoValidator());
        }
    }
}
