using CV.Application.DTOs.Educations;
using CV.Application.DTOs.Projectss;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Projects.Requests.Queries
{
    public class GetProjectListRequest : IRequest<List<ProjectDto>>
    {
    }
}
