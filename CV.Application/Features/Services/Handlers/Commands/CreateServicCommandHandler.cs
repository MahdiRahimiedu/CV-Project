using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Services.Validators;
using CV.Application.Features.Services.Requests.Commands;
using CV.Application.Response;
using CV.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Services.Handlers.Commands
{
    public class CreateServicCommandHandler : IRequestHandler<CreateServicCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IServicRepository _servicRepository;

        public CreateServicCommandHandler(IMapper mapper, IServicRepository servicRepository)
        {
            _mapper = mapper;
            _servicRepository = servicRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateServicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateServicDtoValidator();
            var result = await validator.ValidateAsync(request.CreateServicDto);

            if(!result.IsValid)
            {
                response.Success = false;
                response.Message = "creating failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            var servic = _mapper.Map<Servic>(request.CreateServicDto);
            servic = await _servicRepository.AddAsync(servic);
            response.Success = true;
            response.Message = "creating Successful";
            response.Id = servic.Id;
            return response;
        }
    }
}
