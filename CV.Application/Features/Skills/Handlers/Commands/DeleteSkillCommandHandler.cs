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
    public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand , BaseCommandResponse>
    {
        private readonly ISkillRepository _skillRepository;

        public DeleteSkillCommandHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var skill = await _skillRepository.GetByIdAsync(request.Id);

            if (skill == null)
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }

            await _skillRepository.DeleteAsync(skill);

            response.Success = true;
            response.Message = "deleted seccessful";
            return response;
        }
    }
}
