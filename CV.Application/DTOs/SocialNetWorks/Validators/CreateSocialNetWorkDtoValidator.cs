using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.SocialNetWorks.Validators
{
    public class CreateSocialNetWorkDtoValidator : AbstractValidator<CreateSocialNetWorkDto>
    {
        public CreateSocialNetWorkDtoValidator()
        {
            Include(new ISocialNetWorkDtoValidator());
        }
    }
}
