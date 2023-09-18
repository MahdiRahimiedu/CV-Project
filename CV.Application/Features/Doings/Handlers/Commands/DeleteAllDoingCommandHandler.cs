using CV.Application.Contracts.Persistence;
using CV.Application.Features.Doings.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Doings.Handlers.Commands
{
    public class DeleteAllDoingCommandHandler : IRequestHandler<DeleteAllDoingCommand , BaseCommandResponse>
    {
        public IDoingRepository _doingRepository { get; set; }

        public DeleteAllDoingCommandHandler(IDoingRepository doingRepository)
        {
            _doingRepository = doingRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteAllDoingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            if (!await _doingRepository.ExistListAsync(request.Ids))
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }
            await _doingRepository.DeleteAllAsync(request.Ids);
            response.Success = true;
            response.Message = "deleted seccessful";
            return response;
        }
    }
}
