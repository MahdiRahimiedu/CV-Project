using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Skills.Requests.Commands
{
    public class DeleteAllSkillCommand:IRequest<Response.BaseCommandResponse>
    {
        public List<int> Ids { get; set; }
    }
}
