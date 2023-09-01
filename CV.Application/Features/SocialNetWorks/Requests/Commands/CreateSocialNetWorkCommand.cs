using CV.Application.DTOs.SocialNetWorks;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.SocialNetWorks.Requests.Commands
{
    public class CreateSocialNetWorkCommand : IRequest<BaseCommandResponse>
    {
        public CreateSocialNetWorkDto CreateSocialNetWorkDto { get; set; }
    }
}
