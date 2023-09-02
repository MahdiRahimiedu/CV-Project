using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Projects.Validators;
using CV.Application.Features.Projects.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Projects.Handlers.Commands
{
    public class EditProjectCommandHandler : IRequestHandler<EditProjectCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;

        public EditProjectCommandHandler(IMapper mapper, IProjectRepository projectRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
        }

        public async Task<BaseCommandResponse> Handle(EditProjectCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new EditProjectDtoValidator();
            var result = await validator.ValidateAsync(request.EditProjectDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "edited failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var project = await _projectRepository.GetByIdAsync(request.EditProjectDto.Id);

            if (project == null)
            {
                response.Success = false;
                response.Message = "edited failld";
                return response;
            }

            _mapper.Map(request.EditProjectDto , project);
            await _projectRepository.UpdateAsync(project);

            response.Success = true;
            response.Message = "edited successful";
            return response;
        }
    }
}
