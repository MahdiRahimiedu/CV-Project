using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Educations.Validators;
using CV.Application.Features.Educations.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Educations.Handlers.Commands
{
    public class EditEducationCommandHandler : IRequestHandler<EditEducationCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEducationRepository _educationRepository;

        public EditEducationCommandHandler(IMapper mapper, IEducationRepository educationRepository)
        {
            _mapper = mapper;
            _educationRepository = educationRepository;
        }

        public async Task<BaseCommandResponse> Handle(EditEducationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new EditEducationDtoValidator();
            var result = await validator.ValidateAsync(request.EditEducationDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "edited failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var education = await _educationRepository.GetByIdAsync(request.EditEducationDto.Id);

            if (education == null)
            {
                response.Success = false;
                response.Message = "edited failld";
                return response;
            }

            _mapper.Map(request.EditEducationDto, education);
            await _educationRepository.UpdateAsync(education);

            response.Success = true;
            response.Message = "edited successful";
            return response;

        }
    }
}
