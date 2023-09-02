using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Skillss;
using CV.Application.Features.Skills.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Skills.Handlers.Queries
{
    public class GetSkillDetailRequestHandler : IRequestHandler<GetSkillDetailRequest , SkillDto>
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepo;

        public GetSkillDetailRequestHandler(IMapper mapper, ISkillRepository skillRepo)
        {
            _mapper = mapper;
            _skillRepo = skillRepo;
        }

        public async Task<SkillDto> Handle(GetSkillDetailRequest request, CancellationToken cancellationToken)
        {
            var result = await _skillRepo.GetByIdAsync(request.Id);
            return _mapper.Map<SkillDto>(result);
        }
    }
}
