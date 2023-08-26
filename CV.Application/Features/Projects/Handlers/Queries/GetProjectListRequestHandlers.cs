using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Doings;
using CV.Application.DTOs.Projectss;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Features.Projects.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Projects.Handlers.Queries
{
    public class GetProjectListRequestHandlers : IRequestHandler<GetProjectListRequest, List<ProjectDto>>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepo;

        public GetProjectListRequestHandlers(IMapper mapper, IProjectRepository projectRepo)
        {
            _mapper = mapper;
            _projectRepo = projectRepo;
        }

        public async Task<List<ProjectDto>> Handle(GetProjectListRequest request, CancellationToken cancellationToken)
        {
            var project = await _projectRepo.GetAllAsync();
            return _mapper.Map<List<ProjectDto>>(project);
        }
    }
}
