using AutoMapper;
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
    public class ChangeSeenContactMeCommandHandler:IRequestHandler<ChangeSeenContactMeCommand,BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactMeRepository _contactMeRepo;

        public ChangeSeenContactMeCommandHandler(IMapper mapper, IContactMeRepository contactMeRepo)
        {
            _mapper = mapper;
            _contactMeRepo = contactMeRepo;
        }

        public async Task<BaseCommandResponse> Handle(ChangeSeenContactMeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var contactMe = await _contactMeRepo.GetByIdAsync(request.Id);
            if (contactMe == null || contactMe.Seen == true)
            {
                response.Success = false;
                response.Message = "Change failld";
                return response;
            }
            await _contactMeRepo.ChengeSeenStatusAsync(contactMe);


            response.Success = true;
            response.Message = "Change successful";
            return response;
        }
    }
}
