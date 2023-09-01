using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Skills.Validators;
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
    public class EditSkillCommandHandler : IRequestHandler<EditSkillCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;

        public EditSkillCommandHandler(IMapper mapper, ISkillRepository skillRepository)
        {
            _mapper = mapper;
            _skillRepository = skillRepository;
        }

        public async Task<BaseCommandResponse> Handle(EditSkillCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new EditSkillDtoValidator();
            var result = await validator.ValidateAsync(request.EditSkillDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "edited failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var skill = await _skillRepository.GetByIdAsync(request.EditSkillDto.Id);

            if (skill == null)
            {
                response.Success = false;
                response.Message = "edited failld";
                return response;
            }

            _mapper.Map(request.EditSkillDto, skill);
            await _skillRepository.UpdateAsync(skill);

            response.Success = true;
            response.Message = "edited successful";
            return response;

        }
    }
}
