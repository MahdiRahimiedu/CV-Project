using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.AboutUs;
using CV.Application.Features.AboutUs.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.AboutUs.Handlers.Queries
{
    public class GetAboutUsListRequestHandler : IRequestHandler<GetAboutUsListRequest, List<AboutUsDto>>
    {
        private readonly IAboutUsRepository _repository;
        private readonly IMapper _mapper;

        public GetAboutUsListRequestHandler(IAboutUsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<AboutUsDto>> Handle(GetAboutUsListRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<List<AboutUsDto>>(result);
        }
    }
}
