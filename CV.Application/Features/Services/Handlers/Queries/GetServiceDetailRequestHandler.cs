using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Servicess;
using CV.Application.Features.Services.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Services.Handlers.Queries
{
    public class GetServiceDetailRequestHandler : IRequestHandler<GetServiceDetailRequest , ServicDto>
    {
        private readonly IMapper _mapper;
        private readonly IServicRepository _serviceRepo;

        public GetServiceDetailRequestHandler(IMapper mapper, IServicRepository serviceRepo)
        {
            _mapper = mapper;
            _serviceRepo = serviceRepo;
        }

        public async Task<ServicDto> Handle(GetServiceDetailRequest request, CancellationToken cancellationToken)
        {
            var result = await _serviceRepo.GetByIdAsync(request.Id);
            return _mapper.Map<ServicDto>(result);
        }
    }
}
