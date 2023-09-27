using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.Features.AboutUs.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.AboutUs.Handlers.Comannds
{
    public class CreateAboutUsCommandHandler : IRequestHandler<CreateAboutUsCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAboutUsRepository _repository;

        public CreateAboutUsCommandHandler(IMapper mapper, IAboutUsRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<BaseCommandResponse> Handle(CreateAboutUsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            try
            {
                var aboutUs = _mapper.Map<Domain.AboutUs>(request.CreateAboutUsDto);
                aboutUs = await _repository.AddAsync(aboutUs);
                response.Success = true;
                response.Message = "creation Successful";
                response.Id = aboutUs.Id;
                return response;
            }
            catch (Exception)
            {
                response.Success = false;
                response.Message = "creation failld";
                return response;

            }
            
        }
    }
}
