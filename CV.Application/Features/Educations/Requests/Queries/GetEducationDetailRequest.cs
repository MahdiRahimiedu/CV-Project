using CV.Application.DTOs.Educations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Educations.Requests.Queries
{
    public class GetEducationDetailRequest : IRequest<EducationDto>
    {
        public int Id { get; set; }
    }
}
