using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Doings;
using CV.Application.DTOs.Skillss;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Features.Skills.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Skills.Handlers.Queries
{
    public class GetSkillListRequestHandlers : IRequestHandler<GetSkillListRequest, List<SkillDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepo;

        public GetSkillListRequestHandlers(IMapper mapper, ISkillRepository skillRepo)
        {
            _mapper = mapper;
            _skillRepo = skillRepo;
        }

        public async Task<List<SkillDto>> Handle(GetSkillListRequest request, CancellationToken cancellationToken)
        {
            var skill = await _skillRepo.GetAllAsync();
            return _mapper.Map<List<SkillDto>>(skill);
        }
    }
}
