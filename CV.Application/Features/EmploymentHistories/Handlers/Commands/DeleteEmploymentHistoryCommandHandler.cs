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
    public class DeleteEmploymentHistoryCommandHandler : IRequestHandler<DeleteEmploymentHistoryCommand , BaseCommandResponse>
    {
        private readonly IEmploymentHistoryRepository _employmentHistoryRepo;

        public DeleteEmploymentHistoryCommandHandler(IEmploymentHistoryRepository employmentHistoryRepo)
        {
            _employmentHistoryRepo = employmentHistoryRepo;
        }

        public async Task<BaseCommandResponse> Handle(DeleteEmploymentHistoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var employmentHistory = await _employmentHistoryRepo.GetByIdAsync(request.Id);

            if (employmentHistory == null)
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }

            await _employmentHistoryRepo.DeleteAsync(employmentHistory);

            response.Success = true;
            response.Message = "deleted seccessful";
            return response;
        }
    }
}
