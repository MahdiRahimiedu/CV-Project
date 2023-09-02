using CV.Application.DTOs.ContactMes;
using CV.Application.DTOs.EmploymentHistories;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.EmploymentHistories.Requests.Commands
{
    public class CreateEmploymentHistoryCommend : IRequest<BaseCommandResponse>
    {
        public CreateEmploymentHistoryDto CreateEmploymentHistoryDto { get; set; }
    }
}
