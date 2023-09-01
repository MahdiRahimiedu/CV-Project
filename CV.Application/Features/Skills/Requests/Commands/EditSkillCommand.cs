using CV.Application.DTOs.Skills;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Skills.Requests.Commands
{
    public class EditSkillCommand : IRequest<BaseCommandResponse>
    {
        public EditSkillDto EditSkillDto { get; set; }
    }
}
