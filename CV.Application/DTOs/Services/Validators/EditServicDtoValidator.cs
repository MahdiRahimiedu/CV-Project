using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Services.Validators
{
    public class EditServicDtoValidator : AbstractValidator<EditServicDto>
    {
        public EditServicDtoValidator()
        {
            Include(new IServicDtoValidator());
        }
    }
}
