using CV.Application.Contracts.Persistence;
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
    public class DeleteEducationCommandHandler : IRequestHandler<DeleteEducationCommand , BaseCommandResponse>
    {
        private readonly IEducationRepository _educationRepository;

        public DeleteEducationCommandHandler(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var education = await _educationRepository.GetByIdAsync(request.Id);

            if (education == null)
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }

            await _educationRepository.DeleteAsync(education);

            response.Success = true;
            response.Message = "deleted successful";
            return response;
        }
    }
}
