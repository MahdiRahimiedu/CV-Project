using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Doings.Requests.Commands
{
    public class DeleteAllDoingCommand : IRequest<BaseCommandResponse>
    {
        public List<int> Ids { get; set; }
    }
}
