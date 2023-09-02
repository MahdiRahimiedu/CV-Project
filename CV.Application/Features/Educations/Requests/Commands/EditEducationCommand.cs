using CV.Application.DTOs.Educations;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Educations.Requests.Commands
{
    public class EditEducationCommand : IRequest<BaseCommandResponse>
    {
        public EditEducationDto EditEducationDto { get; set; }
    }
}
