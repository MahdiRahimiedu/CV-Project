using CV.Application.DTOs.Services;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Services.Requests.Commands
{
    public class EditServicCommand : IRequest<BaseCommandResponse>
    {
        public EditServicDto EditServicDto { get; set; }
    }
}
