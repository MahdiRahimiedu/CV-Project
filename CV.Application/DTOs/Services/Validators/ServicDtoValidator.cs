using CV.Application.DTOs.Servicess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Services.Validators
{
    public class ServicDtoValidator : AbstractValidator<ServicDto>
    {
        public ServicDtoValidator()
        {
            Include(new IServicDtoValidator());
        }
    }
}
