using CV.Application.DTOs.ContactMes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.ContactMes.Requests.Commands
{
    public class ChangeNoteContactMeCommand:IRequest<Response.BaseCommandResponse>
    {
        public ChangeNoteContactMeDto changeNoteContactMeDto { get; set; }
    }
}
