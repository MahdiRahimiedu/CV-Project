using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.SocialNetWorks.Validators;
using CV.Application.Features.SocialNetWorks.Requests.Commands;
using CV.Application.Response;
using CV.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.SocialNetWorks.Handlers.Commands
{
    public class CreateSocialNetWorkCommandHandler : IRequestHandler<CreateSocialNetWorkCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialNetWorkRepository _socialNetWorkRepository;

        public CreateSocialNetWorkCommandHandler(IMapper mapper, ISocialNetWorkRepository socialNetWorkRepository)
        {
            _mapper = mapper;
            _socialNetWorkRepository = socialNetWorkRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateSocialNetWorkCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSocialNetWorkDtoValidator();
            var result = await validator.ValidateAsync(request.CreateSocialNetWorkDto);

            if(!result.IsValid)
            {
                response.Success = false;
                response.Message = "creating failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            var socialNetWork = _mapper.Map<SocialsNetWork>(request.CreateSocialNetWorkDto);
            socialNetWork = await _socialNetWorkRepository.AddAsync(socialNetWork);
            response.Success = true;
            response.Message = "creating Successful";
            response.Id = socialNetWork.Id;
            return response;
        }
    }
}
