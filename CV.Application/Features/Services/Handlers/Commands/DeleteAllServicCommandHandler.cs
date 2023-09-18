using CV.Application.Contracts.Persistence;
using CV.Application.Features.Services.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Services.Handlers.Commands
{
    public class DeleteAllServicCommandHandler : IRequestHandler<DeleteAllServicCommand , BaseCommandResponse>
    {
        public IServicRepository _servicRepo { get; set; }

        public DeleteAllServicCommandHandler(IServicRepository servicRepo)
        {
            _servicRepo = servicRepo;
        }

        public async Task<BaseCommandResponse> Handle(DeleteAllServicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            if (!await _servicRepo.ExistListAsync(request.Ids))
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }
            await _servicRepo.DeleteAllAsync(request.Ids);
            response.Success = true;
            response.Message = "deleted seccessful";
            return response;
        }
    }
}
