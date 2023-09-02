﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Educations.Validators
{
    public class EdicutionDtoValidator : AbstractValidator<EducationDto>
    {
        public EdicutionDtoValidator()
        {
            Include(new IEducationDtoValidator());
        }
    }
}
