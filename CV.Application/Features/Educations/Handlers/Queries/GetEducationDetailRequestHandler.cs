using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Educations;
using CV.Application.Features.Educations.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Educations.Handlers.Queries
{
    public class GetEducationDetailRequestHandler : IRequestHandler<GetEducationDetailRequest , EducationDto>
    {
        private readonly IMapper _mapper;
        private readonly IEducationRepository _educationRepository;

        public GetEducationDetailRequestHandler(IMapper mapper, IEducationRepository educationRepository)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
        }

        public async Task<EducationDto> Handle(GetEducationDetailRequest request, CancellationToken cancellationToken)
        {
            var result = await _educationRepository.GetByIdAsync(request.Id);
            return _mapper.Map<EducationDto>(result);
        }
    }
}
