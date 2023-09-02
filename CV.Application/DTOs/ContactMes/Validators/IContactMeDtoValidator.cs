using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.ContactMes.Validators
{
    public class IContactMeDtoValidator : AbstractValidator<IContactMeDto>
    {
        public IContactMeDtoValidator()
        {
            RuleFor(o => o.Name).NotEmpty().WithMessage("Fill in the name field")
                .MaximumLength(50).WithMessage("The length of the entered text is not correct");

            RuleFor(o => o.Email).NotEmpty().WithMessage("Fill in the email field")
                .EmailAddress().WithMessage("your email address fualse");

            RuleFor(o => o.MessageTitle).NotEmpty().WithMessage("Fill in the message title field")
                .MaximumLength(50).WithMessage("The length of the entered text is not correct");

            RuleFor(o => o.Message).NotEmpty().WithMessage("Fill in the message field")
                .MaximumLength(150).WithMessage("The length of the entered text is not correct");
                
        }
    }
}
