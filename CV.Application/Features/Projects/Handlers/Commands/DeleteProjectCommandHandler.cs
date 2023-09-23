using CV.Application.Contracts.Persistence;
using CV.Application.Features.Projects.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Projects.Handlers.Commands
{
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand , BaseCommandResponse>
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var project = await _projectRepository.GetByIdAsync(request.Id);

            if (project == null)
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }

            await _projectRepository.DeleteAsync(project);

            response.Success = true;
            response.Message = "deleted faild";
            return response;
        }
    }
}
