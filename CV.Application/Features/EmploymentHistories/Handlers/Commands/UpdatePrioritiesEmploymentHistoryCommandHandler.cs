using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.Features.EmploymentHistories.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.EmploymentHistories.Handlers.Commands
{
    public class UpdatePrioritiesEmploymentHistoryCommandHandler : IRequestHandler<UpdatePrioritiesEmploymentHistoryCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmploymentHistoryRepository _employmentHistoryRepository;

        public UpdatePrioritiesEmploymentHistoryCommandHandler(IMapper mapper, IEmploymentHistoryRepository employmentHistoryRepository)
        {
            _mapper = mapper;
            _employmentHistoryRepository = employmentHistoryRepository;
        }

        public async Task<BaseCommandResponse> Handle(UpdatePrioritiesEmploymentHistoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var result = await _employmentHistoryRepository.UpdatePrioritiesAsync(request.Ids);

            if (!result)
            {
                response.Success = false;
                response.Message = "edited failld";
                return response;
            }

            response.Success = true;
            response.Message = "edited successful";
            return response;
        }
    }
}
