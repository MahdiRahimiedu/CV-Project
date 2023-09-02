using FluentValidation;
using FluentValidation.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.ContactMes.Validators
{
    public class ContactMeDtoValidator : AbstractValidator<ContactMeDto>
    {
        public ContactMeDtoValidator()
        {
            Include(new IContactMeDtoValidator());
        }
    }
}
