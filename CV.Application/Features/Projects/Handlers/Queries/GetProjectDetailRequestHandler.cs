using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Projectss;
using CV.Application.Features.Projects.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Projects.Handlers.Queries
{
    public class GetProjectDetailRequestHandler : IRequestHandler<GetProjectDetailRequest , ProjectDto>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;

        public GetProjectDetailRequestHandler(IMapper mapper, IProjectRepository projectRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDto> Handle(GetProjectDetailRequest request, CancellationToken cancellationToken)
        {
            var result = await _projectRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ProjectDto>(result);
        }
    }
}
