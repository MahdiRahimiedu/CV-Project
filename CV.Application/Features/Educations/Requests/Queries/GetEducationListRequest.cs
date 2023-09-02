using CV.Application.DTOs.Educations;
using CV.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Educations.Requests.Queries
{
    public class GetEducationListRequest : IRequest<List<EducationDto>>
    {
    }
}
