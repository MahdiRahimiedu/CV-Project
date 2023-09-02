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
    public class DeleteServicCommandHandler : IRequestHandler<DeleteServicCommand , BaseCommandResponse>
    {
        private readonly IServicRepository _servicRepository;

        public DeleteServicCommandHandler(IServicRepository servicRepository)
        {
            _servicRepository = servicRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteServicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var servic = await _servicRepository.GetByIdAsync(request.Id);

            if (servic == null)
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }

            await _servicRepository.DeleteAsync(servic);

            response.Success = true;
            response.Message = "deleted seccessful";
            return response;
        }
    }
}
