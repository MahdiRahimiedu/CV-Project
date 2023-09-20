using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Doings;
using CV.Application.DTOs.EmploymentHistories;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Features.EmploymentHistories.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.EmploymentHistories.Handlers.Queries
{
    public class GetEmploymentHistoryListRequestHandlers : IRequestHandler<GetEmploymentHistoryListRequest, List<EmploymentHistoryDto>>
    {
        private readonly IMapper _mapper;
        private readonly IEmploymentHistoryRepository _employmentHestoryRepo;

        public GetEmploymentHistoryListRequestHandlers(IMapper mapper, IEmploymentHistoryRepository employmentHestoryRepo)
        {
            _mapper = mapper;
            _employmentHestoryRepo = employmentHestoryRepo;
        }

        public async Task<List<EmploymentHistoryDto>> Handle(GetEmploymentHistoryListRequest request, CancellationToken cancellationToken)
        {
            var employmentRepo = await _employmentHestoryRepo.GetAllSortedPriority();
            return _mapper.Map<List<EmploymentHistoryDto>>(employmentRepo);
        }
    }

}
