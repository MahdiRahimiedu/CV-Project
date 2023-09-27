using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Doings.Validators;
using CV.Application.Features.AboutUs.Requests.Commands;
using CV.Application.Features.Doings.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.AboutUs.Handlers.Comannds
{
    public class EditAboutUsCommandHandler : IRequestHandler<EditAboutUsCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAboutUsRepository _repository;

        public EditAboutUsCommandHandler(IMapper mapper, IAboutUsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<BaseCommandResponse> Handle(EditAboutUsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            try
            {
                var doing = await _repository.GetByIdAsync(request.UpdateAboutUsDto.Id);

                if (doing == null)
                {
                    response.Success = false;
                    response.Message = "editing failld";
                    return response;
                }
                _mapper.Map(request.UpdateAboutUsDto, doing);

                await _repository.UpdateAsync(doing);
                response.Success = true;
                response.Message = "editing seccses";
                return response;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "editing failld";
                return response;
            }
        }
    }
}
