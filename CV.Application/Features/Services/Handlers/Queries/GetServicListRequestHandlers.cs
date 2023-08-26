using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Doings;
using CV.Application.DTOs.Servicess;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Features.Services.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Services.Handlers.Queries
{
    public class GetServicListRequestHandlers : IRequestHandler<GetServicListRequest, List<ServicDto>>
    {
        private readonly IMapper _mapper;
        private readonly IServicRepository _serviceRepo;

        public GetServicListRequestHandlers(IMapper mapper, IServicRepository serviceRepo)
        {
            _mapper = mapper;
            _serviceRepo = serviceRepo;
        }

        public async Task<List<ServicDto>> Handle(GetServicListRequest request, CancellationToken cancellationToken)
        {
            var servic = await _serviceRepo.GetAllAsync();
            return _mapper.Map<List<ServicDto>>(servic);
        }
    }
}
