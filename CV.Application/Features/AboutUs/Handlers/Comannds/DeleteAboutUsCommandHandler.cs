using AutoMapper;
using CV.Application.Contracts.Persistence;
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
    public class DeleteAboutUsCommandHandler : IRequestHandler<DeleteAboutUsCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAboutUsRepository _repository;

        public DeleteAboutUsCommandHandler(IMapper mapper, IAboutUsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<BaseCommandResponse> Handle(DeleteAboutUsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            try
            {
                
                await _repository.DeleteAsync(request.Id);
                response.Success = true;
                response.Message = "deleted Successful";
                response.Id = request.Id;
                return response;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "deleted failld";
                return response;

            }
        }
    }
}
