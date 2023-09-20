using CV.Application.Features.Educations.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Educations.Handlers.Commands
{
    public class ChangeEducationCommandHandler : IRequestHandler<ChangeEducationCommand, BaseCommandResponse>
    {
        public Task<BaseCommandResponse> Handle(ChangeEducationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
