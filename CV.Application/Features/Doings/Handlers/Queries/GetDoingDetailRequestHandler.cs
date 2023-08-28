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
    public class GetDoingDetailRequestHandler : IRequestHandler<GetDoingDetailRequest , DoingDto>
    {
        private IMapper _mapper;
        private IDoingRepository _doingRepo;

        public GetDoingDetailRequestHandler(IMapper mapper, IDoingRepository doingRepo)
        {
            _mapper = mapper;
            _doingRepo = doingRepo;
        }

        public async Task<DoingDto> Handle(GetDoingDetailRequest request, CancellationToken cancellationToken)
        {
            var result = await _doingRepo.GetByIdAsync(request.Id);
            return _mapper.Map<DoingDto>(result);
        }
    }
}
