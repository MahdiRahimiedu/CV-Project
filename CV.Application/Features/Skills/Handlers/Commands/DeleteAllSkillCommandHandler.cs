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
    public class DeleteAllSkillCommandHandler : IRequestHandler<DeleteAllSkillCommand, BaseCommandResponse>
    {
        public ISkillRepository _skillRepository { get; set; }

        public DeleteAllSkillCommandHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteAllSkillCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            if (!await _skillRepository.ExistListAsync(request.Ids))
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }
            await _skillRepository.DeleteAllAsync(request.Ids);
            response.Success = true;
            response.Message = "deleted seccessful";
            return response;

        }
    }
}
