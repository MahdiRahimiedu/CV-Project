using CV.Application.Contracts.Persistence;
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
    public class DeleteSocialNewWorkCommandHAndler : IRequestHandler<DeleteSocialNewWorkCommand , BaseCommandResponse>
    {
        private readonly ISocialNetWorkRepository _socialNetWorkRepository;

        public DeleteSocialNewWorkCommandHAndler(ISocialNetWorkRepository socialNetWorkRepository)
        {
            _socialNetWorkRepository = socialNetWorkRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteSocialNewWorkCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var socialNetWork = await _socialNetWorkRepository.GetByIdAsync(request.Id);

            if (socialNetWork == null)
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }

            await _socialNetWorkRepository.DeleteAsync(socialNetWork);

            response.Success = true;
            response.Message = "deleted seccessful";
            return response;
        }
    }
}
