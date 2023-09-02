using CV.Application.DTOs.Doings;
using CV.Application.Features.Doings.Handlers.Queries;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Doings.Requests.Commands
{
    public class EditDoingCommand : IRequest<BaseCommandResponse>
    {
        public EditDoingDto EditDoingDto { get; set; }
    }
}
