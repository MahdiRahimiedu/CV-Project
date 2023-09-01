using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.EmploymentHistories.Validators
{
    public class CreateEmploymentHistoryDtoValidator : AbstractValidator<CreateEmploymentHistoryDto>
    {
        public CreateEmploymentHistoryDtoValidator()
        {
            Include(new IEmploymentHistoryDtoValidator());
        }
    }
}
