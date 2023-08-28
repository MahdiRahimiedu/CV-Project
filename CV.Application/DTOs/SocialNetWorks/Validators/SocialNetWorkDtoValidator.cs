using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.SocialNetWorks.Validators
{
    public class SocialNetWorkDtoValidator : AbstractValidator<ISocialNetWorkDto>
    {
        public SocialNetWorkDtoValidator()
        {
            Include(new ISocialNetWorkDtoValidator());
        }
    }
}
