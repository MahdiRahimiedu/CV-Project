using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Doings;
using CV.Application.DTOs.Doings.Validators;
using CV.Application.Features.Doings.Requests.Commands;
using CV.Application.Response;
using CV.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Doings.Handlers.Commands
{
    public class CreateDoingCommandHandler : IRequestHandler<CreateDoingCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDoingRepository _doingRepo;

        public CreateDoingCommandHandler(IMapper mapper, IDoingRepository doingRepo)
        {
            _mapper = mapper;
            _doingRepo = doingRepo;
        }

        public async Task<BaseCommandResponse> Handle(CreateDoingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDoingDtoValidator();
            var result = await validator.ValidateAsync(request.CreateDoingDto);
            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "creation failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            var doing = _mapper.Map<Doing>(request.CreateDoingDto);
            doing = await _doingRepo.AddAsync(doing);
            response.Success = true;
            response.Message = "creation Successful";
            response.Id = doing.Id;
            return response;
        }
    }
}
