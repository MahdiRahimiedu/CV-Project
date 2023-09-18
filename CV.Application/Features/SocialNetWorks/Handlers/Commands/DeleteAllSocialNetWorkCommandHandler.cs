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
    public class DeleteAllSocialNetWorkCommandHandler : IRequestHandler<DeleteAllSocialNetWorkCommand , BaseCommandResponse>
    {
        public ISocialNetWorkRepository _socialNetWorkRepo { get; set; }

        public DeleteAllSocialNetWorkCommandHandler(ISocialNetWorkRepository socialNetWorkRepo)
        {
            _socialNetWorkRepo = socialNetWorkRepo;
        }

        public async Task<BaseCommandResponse> Handle(DeleteAllSocialNetWorkCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            if (!await _socialNetWorkRepo.ExistListAsync(request.Ids))
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }
            await _socialNetWorkRepo.DeleteAllAsync(request.Ids);
            response.Success = true;
            response.Message = "deleted seccessful";
            return response;
        }
    }
}
