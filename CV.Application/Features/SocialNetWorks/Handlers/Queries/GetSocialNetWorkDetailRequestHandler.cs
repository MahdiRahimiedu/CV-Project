using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.SocialNetWorks;
using CV.Application.DTOs.SocialNetWorkss;
using CV.Application.Features.SocialNetWorks.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.SocialNetWorks.Handlers.Queries
{
    public class GetSocialNetWorkDetailRequestHandler : IRequestHandler<GetSocialNetWorkDetailRequest , SocialsNetWorkDto>
    {
        private readonly IMapper _mapper;
        private readonly ISocialNetWorkRepository _socialNetWorkRepo;

        public GetSocialNetWorkDetailRequestHandler(IMapper mapper, ISocialNetWorkRepository socialNetWorkRepo)
        {
            _mapper = mapper;
            _socialNetWorkRepo = socialNetWorkRepo;
        }

        public async Task<SocialsNetWorkDto> Handle(GetSocialNetWorkDetailRequest request, CancellationToken cancellationToken)
        {
            var result = await _socialNetWorkRepo.GetByIdAsync(request.Id);
            return _mapper.Map<SocialsNetWorkDto>(result);
        }
    }
}
