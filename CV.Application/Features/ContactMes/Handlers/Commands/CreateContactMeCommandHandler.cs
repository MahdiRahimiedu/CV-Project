using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.ContactMes.Validators;
using CV.Application.DTOs.Doings.Validators;
using CV.Application.Features.ContactMes.Requests.Commands;
using CV.Application.Response;
using CV.Domain;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.ContactMes.Handlers.Commands
{
    public class CreateContactMeCommandHandler : IRequestHandler<CreateContactMeCommand , BaseCommandResponse>
    {
        private readonly IMapper _mappre;
        private readonly IContactMeRepository _contactMeRepository;

        public CreateContactMeCommandHandler(IMapper mappre, IContactMeRepository contactMeRepository)
        {
            _mappre = mappre;
            _contactMeRepository = contactMeRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateContactMeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateContactMeDtoValidator();
            var result = await validator.ValidateAsync(request.CreateContactMeDto);

            if(!result.IsValid)
            {
                response.Success = false;
                response.Message = "creation failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            var contactMe = _mappre.Map<ContactMe>(request.CreateContactMeDto);
            contactMe = await _contactMeRepository.AddAsync(contactMe);
            response.Success = true;
            response.Message = "creation Successful";
            response.Id = contactMe.Id;
            return response;
        

        }
    }
}
