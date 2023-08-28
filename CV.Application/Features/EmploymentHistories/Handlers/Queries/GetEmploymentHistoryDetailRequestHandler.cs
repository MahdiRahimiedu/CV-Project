using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.EmploymentHistories;
using CV.Application.Features.EmploymentHistories.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.EmploymentHistories.Handlers.Queries
{
    public class GetEmploymentHistoryDetailRequestHandler : IRequestHandler<GetEmploymentHistoryDetailRequest , EmploymentHistoryDto>
    {
        private readonly IMapper _mapper;
        private readonly IEmploymentHistoryRepository _employmentHistoryRepository;

        public GetEmploymentHistoryDetailRequestHandler(IMapper mapper, IEmploymentHistoryRepository employmentHistoryRepository)
        {
            _mapper = mapper;
            _employmentHistoryRepository = employmentHistoryRepository;
        }

        public async Task<EmploymentHistoryDto> Handle(GetEmploymentHistoryDetailRequest request, CancellationToken cancellationToken)
        {
            var result = await _employmentHistoryRepository.GetByIdAsync(request.Id);
            return _mapper.Map<EmploymentHistoryDto>(result);
        }
    }
}
