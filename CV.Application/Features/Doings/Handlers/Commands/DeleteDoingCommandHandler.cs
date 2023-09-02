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
    public class DeleteDoingCommandHandler : IRequestHandler<DeleteDoingCommand , BaseCommandResponse>
    {
        private readonly IDoingRepository _doingRepo;

        public DeleteDoingCommandHandler(IDoingRepository doingRepo)
        {
            _doingRepo = doingRepo;
        }

        public async Task<BaseCommandResponse> Handle(DeleteDoingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var doing = await _doingRepo.GetByIdAsync(request.Id);
            if(doing == null)
            {
                response.Success = false;
                response.Message = "deleted failld";
                return response;
            }
            await _doingRepo.DeleteAsync(doing);
            response.Success = true;
            response.Message = "deleted Successful";
            return response;

        }
    }
}
