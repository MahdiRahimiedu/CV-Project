using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.EmploymentHistories.Validators;
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
    public class EditEmploymentHistoryCommandHandler : IRequestHandler<EditEmploymentHistoryCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmploymentHistoryRepository _employmentHistoryRepo;

        public EditEmploymentHistoryCommandHandler(IMapper mapper, IEmploymentHistoryRepository employmentHistoryRepo)
        {
            _mapper = mapper;
            _employmentHistoryRepo = employmentHistoryRepo;
        }

        public async Task<BaseCommandResponse> Handle(EditEmploymentHistoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new EditEmploymentHistoryDtoValidator();
            var result = await validator.ValidateAsync(request.EditEmploymentHistoryDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "edited failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var employmentHistory = await _employmentHistoryRepo.GetByIdAsync(request.EditEmploymentHistoryDto.Id);

            if (employmentHistory == null)
            {
                response.Success = false;
                response.Message = "edited failld";
                return response;
            }

            _mapper.Map(request.EditEmploymentHistoryDto, employmentHistory);
            await _employmentHistoryRepo.UpdateAsync(employmentHistory);

            response.Success = true;
            response.Message = "edited successful";
            return response;
        }
    }
}
