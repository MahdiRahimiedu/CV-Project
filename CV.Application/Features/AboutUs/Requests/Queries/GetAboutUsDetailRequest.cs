using CV.Application.DTOs.AboutUs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.AboutUs.Requests.Queries
{
    public class GetAboutUsDetailRequest:IRequest<AboutUsDto>
    {
        public int Id { get; set; }
    }
}
