using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.ContactMes.Requests.Commands
{
    public class ChangeSeenContactMeCommand:IRequest<Response.BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
