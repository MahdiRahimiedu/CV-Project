using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Educations;
using CV.Application.DTOs.Educations.Validators;
using CV.Application.Features.Educations.Requests.Commands;
using CV.Application.Response;
using CV.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Educations.Handlers.Commands
{
    public class CreateEducationCommandHandler : IRequestHandler<CreateEducationCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationRepository _educationRepository;

        public CreateEducationCommandHandler(IMapper mapper, IEducationRepository educationRepository)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEducationDtoValidator();
            var result = await validator.ValidateAsync(request.CreateEducationDto);

            if(!result.IsValid)
            {
                response.Success = false;
                response.Message = "creating failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            var education = _mapper.Map<Education>(request.CreateEducationDto);
            education = await _educationRepository.AddAsync(education);
            response.Success = true;
            response.Message = "creating Successful";
            response.Id = education.Id;
            return response;
        }
    }
}
