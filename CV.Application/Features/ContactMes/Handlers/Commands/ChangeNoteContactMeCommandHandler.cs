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
    public class ChangeNoteContactMeCommandHandler : IRequestHandler<ChangeNoteContactMeCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IContactMeRepository _contactMeRepo;

        public ChangeNoteContactMeCommandHandler(IMapper mapper, IContactMeRepository contactMeRepo)
        {
            _mapper = mapper;
            _contactMeRepo = contactMeRepo;
        }

        public async Task<BaseCommandResponse> Handle(ChangeNoteContactMeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new ChangeNoteContactMeDtoValidator();
            var result = await validator.ValidateAsync(request.changeNoteContactMeDto);

            if (!result.IsValid|| !await _contactMeRepo.ExistAsync(request.changeNoteContactMeDto.Id))
            {
                response.Success = false;
                response.Message = "Change failld";
                response.Erorrs = result.Errors.Select(p => p.ErrorMessage).ToList();
            }

            var contactMe = await _contactMeRepo.GetByIdAsync(request.changeNoteContactMeDto.Id);
            _mapper.Map(request.changeNoteContactMeDto, contactMe);
            await _contactMeRepo.UpdateAsync(contactMe);

            response.Success = true;
            response.Message = "Change successful";
            return response;
        }
    }
}
