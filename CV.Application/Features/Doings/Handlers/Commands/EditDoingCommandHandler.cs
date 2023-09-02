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
    public class EditDoingCommandHandler : IRequestHandler<EditDoingCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDoingRepository _doingRepo;

        public EditDoingCommandHandler(IMapper mapper, IDoingRepository doingRepo)
        {
            _mapper = mapper;
            _doingRepo = doingRepo;
        }

        public async Task<BaseCommandResponse> Handle(EditDoingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new EditDoingDtoValidator();
            var result = await validator.ValidateAsync(request.EditDoingDto);

            if(!result.IsValid)
            {
                response.Success = false;
                response.Message = "editing failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var doing = await _doingRepo.GetByIdAsync(request.EditDoingDto.Id);

            if(doing == null)
            {
                response.Success = false;
                response.Message = "editing failld";
                return response;
            }
            _mapper.Map(request.EditDoingDto, doing);
         
            await _doingRepo.UpdateAsync(doing);
            response.Success = true;
            response.Message = "editing seccses";
            return response;
        }
    }
}
