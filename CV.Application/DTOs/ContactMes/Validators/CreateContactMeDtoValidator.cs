using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.ContactMes.Validators
{
    public class CreateContactMeDtoValidator : AbstractValidator<CreateContactMeDto>
    {
        public CreateContactMeDtoValidator()
        {
            Include(new IContactMeDtoValidator());
        }
    }
}
