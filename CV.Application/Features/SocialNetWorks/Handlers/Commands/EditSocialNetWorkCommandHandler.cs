using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.SocialNetWorks.Validators;
using CV.Application.Features.SocialNetWorks.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.SocialNetWorks.Handlers.Commands
{
    public class EditSocialNetWorkCommandHandler : IRequestHandler<EditSocialNetWorkCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISocialNetWorkRepository _socialNetWorkRepository;

        public EditSocialNetWorkCommandHandler(IMapper mapper, ISocialNetWorkRepository socialNetWorkRepository)
        {
            _mapper = mapper;
            _socialNetWorkRepository = socialNetWorkRepository;
        }

        public async Task<BaseCommandResponse> Handle(EditSocialNetWorkCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new EditSocialNetWorkDtoValidator();
            var result = await validator.ValidateAsync(request.EditSocialNetWorkDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "edited failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var socialNetWork = await _socialNetWorkRepository.GetByIdAsync(request.EditSocialNetWorkDto.Id);

            if (socialNetWork == null)
            {
                response.Success = false;
                response.Message = "edited failld";
                return response;
            }

            _mapper.Map(request.EditSocialNetWorkDto, socialNetWork);
            await _socialNetWorkRepository.UpdateAsync(socialNetWork);

            response.Success = true;
            response.Message = "edited successful";
            return response;
        }
    }
}
