using CV.Application.DTOs.Servicess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Services.Requests.Queries
{
    public class GetServiceDetailRequest : IRequest<ServicDto>
    {
        public int Id { get; set; }
    }
}
