using CV.Application.DTOs.AboutUs;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.AboutUs.Requests.Commands
{
    public class DeleteAboutUsCommand:IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }

    }
}
