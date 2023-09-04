using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.Features.Skills.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Skills.Handlers.Commands
{
    public class UpdatePrioritiesSkillCommandHandler : IRequestHandler<UpdatePrioritiesSkillCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;

        public UpdatePrioritiesSkillCommandHandler(IMapper mapper, ISkillRepository skillRepository)
        {
            _mapper = mapper;
            _skillRepository = skillRepository;
        }

        public async Task<BaseCommandResponse> Handle(UpdatePrioritiesSkillCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var result = await _skillRepository.UpdatePrioritiesAsync(request.Ids);

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
