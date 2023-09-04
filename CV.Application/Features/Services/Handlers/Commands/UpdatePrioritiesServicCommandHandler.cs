using AutoMapper;
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
    public class UpdatePrioritiesServicCommandHandler : IRequestHandler<UpdatePrioritiesServicCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServicRepository _servicRepository;

        public UpdatePrioritiesServicCommandHandler(IMapper mapper, IServicRepository servicRepository)
        {
            _mapper = mapper;
            _servicRepository = servicRepository;
        }

        public async Task<BaseCommandResponse> Handle(UpdatePrioritiesServicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var result = await _servicRepository.UpdatePrioritiesAsync(request.Ids);

            if (!result)
            {
                response.Success = false;
                response.Message = "edited failld";
                return response;
            }

            response.Success = true;
            response.Message = "edited successful";
            return response;
        }
    }
}
