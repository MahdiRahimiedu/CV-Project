using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.AboutUs;
using CV.Application.DTOs.ContactMes;
using CV.Application.Features.AboutUs.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.AboutUs.Handlers.Queries
{
    public class GetAboutUsDetailRequestHandler:IRequestHandler<GetAboutUsDetailRequest, AboutUsDto>
    {
        private readonly IAboutUsRepository _repository;
        private readonly IMapper _mapper;

        public GetAboutUsDetailRequestHandler(IAboutUsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AboutUsDto> Handle(GetAboutUsDetailRequest request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<AboutUsDto>(result);
        }
    }
}
