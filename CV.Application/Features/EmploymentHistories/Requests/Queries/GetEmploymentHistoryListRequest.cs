using CV.Application.DTOs.Educations;
using CV.Application.DTOs.EmploymentHistories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.EmploymentHistories.Requests.Queries
{
    public class GetEmploymentHistoryListRequest : IRequest<List<EmploymentHistoryDto>>
    {
    }
}
