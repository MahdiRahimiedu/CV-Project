using CV.Application.DTOs.EmploymentHistories;
using CV.Application.Features.Educations.Requests.Commands;
using CV.Application.Features.EmploymentHistories.Requests.Commands;
using CV.Application.Features.EmploymentHistories.Requests.Queries;
using CV.Application.Response;
using CV.Domain.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/employmenthistories")]
    [ApiController]
    public class EmploymentHistoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmploymentHistoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmploymentHistoryDto>>> Get()
        {
            var employmentHistories = await _mediator.Send(new GetEmploymentHistoryListRequest());

            return Ok(employmentHistories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<EmploymentHistoryDto>>> Get(int id)
        {
            var employmentHistory = await _mediator.Send(new GetEmploymentHistoryDetailRequest { Id = id });

            return Ok(employmentHistory);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreateEmploymentHistoryDto model)
        {
            var employmentHistory = new CreateEmploymentHistoryCommend { CreateEmploymentHistoryDto = model };

            var apiResponse = await _mediator.Send(employmentHistory);

            return Ok(apiResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Edit(int id , EditEmploymentHistoryDto model)
        {
            var employmentHistory = new EditEmploymentHistoryCommand { EditEmploymentHistoryDto = model };

            var apiResponse = await _mediator.Send(employmentHistory);

            return Ok(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var employmentHistory = new DeleteEmploymentHistoryCommand { Id = id };

            var apiResponse = await _mediator.Send(employmentHistory);

            return Ok(apiResponse);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Priorities(List<int> ids)
        {
            var priorities = new UpdatePrioritiesEmploymentHistoryCommand { Ids = ids };

            var apiResponse = await _mediator.Send(priorities);

            return Ok(apiResponse);
        }
    }
}
