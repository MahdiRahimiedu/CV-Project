using CV.Application.DTOs.Educations;
using CV.Application.DTOs.Skillss;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Skills.Requests.Queries
{
    public class GetSkillListRequest : IRequest<List<SkillDto>>
    {
    }
}
