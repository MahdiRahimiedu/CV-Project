using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.EmploymentHistories.Requests.Commands
{
    public class UpdatePrioritiesEmploymentHistoryCommand:IRequest<Response.BaseCommandResponse>
    {
        public List<int> Ids { get; set; }
    }
}
