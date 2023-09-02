using CV.Application.DTOs.Doings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Doings.Requests.Queries
{
    public class GetDoingDetailRequest : IRequest<DoingDto>
    {
        public int Id { get; set; }
    }
}
