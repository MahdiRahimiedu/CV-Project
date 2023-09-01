using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.EmploymentHistories.Validators
{
    public class EditEmploymentHistoryDtoValidator : AbstractValidator<EditEmploymentHistoryDto>
    {
        public EditEmploymentHistoryDtoValidator()
        {
            Include(new IEmploymentHistoryDtoValidator());
        }
    }
}
