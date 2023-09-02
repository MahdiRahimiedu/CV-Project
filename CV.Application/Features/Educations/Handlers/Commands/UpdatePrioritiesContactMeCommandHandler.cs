using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.Features.Educations.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Educations.Handlers.Commands
{
    public class UpdatePrioritiesContactMeCommandHandler : IRequestHandler<UpdatePrioritiesContactMeCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationRepository _educationRepository;

        public UpdatePrioritiesContactMeCommandHandler(IMapper mapper, IEducationRepository educationRepository)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
        }

        public async Task<BaseCommandResponse> Handle(UpdatePrioritiesContactMeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var result = await _educationRepository.UpdatePrioritiesAsync(request.Ids);

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
