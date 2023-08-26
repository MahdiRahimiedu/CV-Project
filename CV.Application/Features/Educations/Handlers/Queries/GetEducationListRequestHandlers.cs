using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Doings;
using CV.Application.DTOs.Educations;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Features.Educations.Handlers.Queries;
using CV.Application.Features.Educations.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Educations.Handlers.Queries
{
    public class GetEducationListRequestHandlers : IRequestHandler<GetEducationListRequest, List<EducationDto>>
    {
        
        private readonly IMapper _mapper;
        private readonly IEducationRepository _educationRepo;
        public GetEducationListRequestHandlers(IMapper mapper, IEducationRepository educationRepo)
        {
            _mapper = mapper;
            _educationRepo = educationRepo;
        }

        public async Task<List<EducationDto>> Handle(GetEducationListRequest request, CancellationToken cancellationToken)
        {
            var educations = await _educationRepo.GetAllAsync();
            return _mapper.Map<List<EducationDto>>(educations);
        }
    }
}