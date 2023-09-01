using CV.Application.DTOs.ContactMes;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.ContactMes.Requests.Commands
{
    public class CreateContactMeCommand : IRequest<BaseCommandResponse>
    {
        public CreateContactMeDto CreateContactMeDto { get; set; }
    }
}
