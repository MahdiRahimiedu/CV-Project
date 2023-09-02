using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Services.Requests.Commands
{
    public class UpdatePrioritiesServicCommand:IRequest<Response.BaseCommandResponse>
    {
        public List<int> Ids { get; set; }
    }
}
