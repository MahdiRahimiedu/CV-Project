using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Services.Requests.Commands
{
    public class DeleteServicCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
