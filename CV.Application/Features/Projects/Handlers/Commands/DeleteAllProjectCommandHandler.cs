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
    public class DeleteAllProjectCommandHandler : IRequestHandler<DeleteAllProjectCommand , BaseCommandResponse>
    {
        public IProjectRepository _projectRepo { get; set; }

        public DeleteAllProjectCommandHandler(IProjectRepository projectRepo)
        {
            _projectRepo = projectRepo;
        }


        public async Task<BaseCommandResponse> Handle(DeleteAllProjectCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            if (!await _projectRepo.ExistListAsync(request.Ids))
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }
            await _projectRepo.DeleteAllAsync(request.Ids);
            response.Success = true;
            response.Message = "deleted seccessful";
            return response;
        }
    }
}
