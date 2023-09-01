using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Services.Validators
{
    public class CreateServicDtoValidator : AbstractValidator<CreateServicDto>
    {
        public CreateServicDtoValidator()
        {
            Include(new IServicDtoValidator());
        }
    }
}
