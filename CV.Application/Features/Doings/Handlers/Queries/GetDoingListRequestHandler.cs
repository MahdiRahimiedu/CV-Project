using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Doings;
using CV.Application.Features.Doings.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Doings.Handlers.Queries
{
    public class GetDoingListRequestHandler : IRequestHandler<GetDoingListRequest, List<DoingDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDoingRepository _doingRepository;

        public GetDoingListRequestHandler(IMapper mapper, IDoingRepository doingRepository)
        {
            _mapper = mapper;
            _doingRepository = doingRepository;
        }

        public async Task<List<DoingDto>> Handle(GetDoingListRequest request, CancellationToken cancellationToken)
        {
            var doings = await _doingRepository.GetAllAsync();
            return _mapper.Map<List<DoingDto>>(doings);
        }
    }
}
