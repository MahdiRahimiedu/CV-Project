using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Doings;
using CV.Application.DTOs.SocialNetWorkss;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Features.SocialNetWorks.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.SocialNetWorks.Handlers.Queries
{
    public class GetSocialNetWorkListRequestHandlers : IRequestHandler<GetSocialNetWorkListRequest, List<SocialsNetWorkDto>>
    {

        private readonly IMapper _mapper;
        private readonly ISocialNetWorkRepository _socialNetWorkRepo;

        public GetSocialNetWorkListRequestHandlers(IMapper mapper, ISocialNetWorkRepository socialNetWorkRepo)
        {
            _mapper = mapper;
            _socialNetWorkRepo = socialNetWorkRepo;
        }

        public async Task<List<SocialsNetWorkDto>> Handle(GetSocialNetWorkListRequest request, CancellationToken cancellationToken)
        {
            var socialnetwork = await _socialNetWorkRepo.GetAllAsync();
            return _mapper.Map<List<SocialsNetWorkDto>>(socialnetwork);
        }
    }
}
