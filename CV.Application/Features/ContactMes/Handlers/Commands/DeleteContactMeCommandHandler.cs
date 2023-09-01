using CV.Application.Contracts.Persistence;
using CV.Application.Features.ContactMes.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.ContactMes.Handlers.Commands
{
    public class DeleteContactMeCommandHandler : IRequestHandler<DeleteContactMeCommand , BaseCommandResponse>
    {
        private readonly IContactMeRepository _contactMeRepository;

        public DeleteContactMeCommandHandler(IContactMeRepository contactMeRepository)
        {
            _contactMeRepository = contactMeRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteContactMeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            
            var contactme = await _contactMeRepository.GetByIdAsync(request.Id);

            if (contactme == null)
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }

            await _contactMeRepository.DeleteAsync(contactme);

            response.Success = true;
            response.Message = "deleted seccessful";
            return response;    
        }
    }
}
