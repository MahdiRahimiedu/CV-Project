using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Educations.Requests.Commands
{
    public class ChangeEducationCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
        public string Img { get; set; }
    }
}
