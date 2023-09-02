﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Doings.Validators
{
    public class DoingDtoValidator : AbstractValidator<DoingDto>
    {
        public DoingDtoValidator()
        {
            Include(new IDoingDtoValidator());
        }
    }
}
