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
    public class GetContactMeDetailRequestHandler : IRequestHandler<GetContactMeDetailRequest, ContactMeDto>
    {
        private readonly IMapper _mapper;
        private readonly IContactMeRepository _contactMeRepo;

        public GetContactMeDetailRequestHandler(IMapper mapper, IContactMeRepository contactMeRepo)
        {
            _mapper = mapper;
            _contactMeRepo = contactMeRepo;
        }

        public async Task<ContactMeDto> Handle(GetContactMeDetailRequest request, CancellationToken cancellationToken)
        {
            var result = await _contactMeRepo.GetByIdAsync(request.Id);
            return _mapper.Map<ContactMeDto>(result);
        }
    }
}
