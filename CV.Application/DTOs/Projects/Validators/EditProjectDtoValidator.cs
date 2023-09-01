using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Projects.Validators
{
    public class EditProjectDtoValidator : AbstractValidator<EditProjectDto>
    {
        public EditProjectDtoValidator()
        {
            Include(new IProjectDtoValidator());
        }
    }
}
