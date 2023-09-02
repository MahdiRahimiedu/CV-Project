using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Projects.Validators;
using CV.Application.Features.Projects.Requests.Commands;
using CV.Application.Response;
using CV.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Projects.Handlers.Commands
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandHandler(IMapper mapper, IProjectRepository projectRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateProjectDtoValidator();
            var result = await validator.ValidateAsync(request.CreateProjectDto);

            if(!result.IsValid)
            {
                response.Success = false;
                response.Message = "creating failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            var project = _mapper.Map<Project>(request.CreateProjectDto);
            project = await _projectRepository.AddAsync(project);
            response.Success = true;
            response.Message = "creating Successful";
            response.Id = project.Id;
            return response;
        }
    }
}
