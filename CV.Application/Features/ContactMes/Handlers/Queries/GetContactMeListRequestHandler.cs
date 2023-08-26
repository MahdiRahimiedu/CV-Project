using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.ContactMes;
using CV.Application.Features.ContactMes.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.ContactMes.Handlers.Queries
{
    public class GetContactMeListRequestHandler : IRequestHandler<GetContactMeListRequest, List<ContactMeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IContactMeRepository _contactMeRepository;

        public GetContactMeListRequestHandler(IMapper mapper, IContactMeRepository contactMeRepository)
        {
            _mapper = mapper;
            _contactMeRepository = contactMeRepository;
        }

        public async Task<List<ContactMeDto>> Handle(GetContactMeListRequest request, CancellationToken cancellationToken)
        {
            var contactme = await _contactMeRepository.GetAllAsync();
            return _mapper.Map<List<ContactMeDto>>(contactme);
        }
    }
}
