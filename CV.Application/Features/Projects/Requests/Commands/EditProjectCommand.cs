using CV.Application.DTOs.Projects;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Projects.Requests.Commands
{
    public class EditProjectCommand : IRequest<BaseCommandResponse>
    {
        public EditProjectDto EditProjectDto { get; set; }
    }
}
