using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Skills.Validators;
using CV.Application.Features.Skills.Requests.Commands;
using CV.Application.Response;
using CV.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Skills.Handlers.Commands
{
    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;

        public CreateSkillCommandHandler(IMapper mapper, ISkillRepository skillRepository)
        {
            _mapper = mapper;
            _skillRepository = skillRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSkillDtoValidator();
            var result = await validator.ValidateAsync(request.CreateSkillDto);

            if(!result.IsValid)
            {
                response.Success = false;
                response.Message = "create failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            var skill = _mapper.Map<Skill>(request.CreateSkillDto);
            skill.Priority = await _skillRepository.PriorityMaxAsync();
            skill = await _skillRepository.AddAsync(skill);
            response.Success = true;
            response.Message = "creating Successful";
            response.Id = skill.Id;
            return response;
        }
    }
}
