using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Doings.Validators;
using CV.Application.DTOs.EmploymentHistories.Validators;
using CV.Application.Features.ContactMes.Requests.Commands;
using CV.Application.Features.EmploymentHistories.Requests.Commands;
using CV.Application.Response;
using CV.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.EmploymentHistories.Handlers.Commands
{
    public class CreateEmploymentHistoryCommendHandler : IRequestHandler<CreateEmploymentHistoryCommend , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEmploymentHistoryRepository _employmentHistoryRepository;

        public CreateEmploymentHistoryCommendHandler(IMapper mapper, IEmploymentHistoryRepository employmentHistoryRepository)
        {
            _mapper = mapper;
            _employmentHistoryRepository = employmentHistoryRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateEmploymentHistoryCommend request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEmploymentHistoryDtoValidator();
            var result = await validator.ValidateAsync(request.CreateEmploymentHistoryDto);

            if(!result.IsValid)
            {
                response.Success = false;
                response.Message = "creating failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            var employmentHistory = _mapper.Map<EmploymentHistory>(request.CreateEmploymentHistoryDto);
            employmentHistory = await _employmentHistoryRepository.AddAsync(employmentHistory);
            response.Success = true;
            response.Message = "creating Successful";
            response.Id = employmentHistory.Id;
            return response;
        }
    }
}
