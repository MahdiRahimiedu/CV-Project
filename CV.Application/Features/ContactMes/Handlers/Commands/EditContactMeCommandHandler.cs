using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.ContactMes.Validators;
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
    public class EditContactMeCommandHandler : IRequestHandler<EditContactMeCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactMeRepository _contactMeRepository;

        public EditContactMeCommandHandler(IMapper mapper, IContactMeRepository contactMeRepository)
        {
            _mapper = mapper;
            _contactMeRepository = contactMeRepository;
        }

        public async Task<BaseCommandResponse> Handle(EditContactMeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new EditContactMeDtoValidator();
            var result = await validator.ValidateAsync(request.EditContactMeDto);

            if(!result.IsValid)
            {
                response.Success = false;
                response.Message = "edited faild";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var contactme = await _contactMeRepository.GetByIdAsync(request.EditContactMeDto.Id);

            if(contactme == null)
            {
                response.Success = false;
                response.Message = "edited faild";
                return response;
            }

            _mapper.Map(request.EditContactMeDto , contactme);
            await _contactMeRepository.UpdateAsync(contactme);

            response.Success = true;
            response.Message = "edited success";
            return response;
        }
    }
}
