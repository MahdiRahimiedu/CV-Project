using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Services.Validators;
using CV.Application.Features.Services.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Services.Handlers.Commands
{
    public class EditServicCommandHandler : IRequestHandler<EditServicCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServicRepository _servicRepository;

        public EditServicCommandHandler(IMapper mapper, IServicRepository servicRepository)
        {
            _mapper = mapper;
            _servicRepository = servicRepository;
        }

        public async Task<BaseCommandResponse> Handle(EditServicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new EditServicDtoValidator();
            var result = await validator.ValidateAsync(request.EditServicDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "edited failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var servic = await _servicRepository.GetByIdAsync(request.EditServicDto.Id);

            if (servic == null)
            {
                response.Success = false;
                response.Message = "edited failld";
                return response;
            }

            _mapper.Map(request.EditServicDto, servic);
            await _servicRepository.UpdateAsync(servic);

            response.Success = true;
            response.Message = "edited successful";
            return response;

        }
    }
}
