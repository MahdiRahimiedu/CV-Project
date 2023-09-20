using CV.Application.DTOs.Educations;
using CV.Application.Features.Educations.Requests.Commands;
using CV.Application.Features.Educations.Requests.Queries;
using CV.Application.Features.Services.Requests.Commands;
using CV.Application.Features.SocialNetWorks.Requests.Queries;
using CV.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/educations")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EducationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<EducationDto>>> Get()
        {
            var educations = await _mediator.Send(new GetEducationListRequest());

            return Ok(educations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EducationDto>> Get(int id)
        {
            var education = await _mediator.Send(new GetEducationDetailRequest { Id = id });

            return Ok(education);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreateEducationDto model)
        {
            var education = new CreateEducationCommand { CreateEducationDto = model };

            var apiResponse = await _mediator.Send(education);

            return Ok(apiResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Edit(int id, EditEducationDto model)
        {
            var education = new EditEducationCommand { EditEducationDto = model };

            var apiResponse = await _mediator.Send(education);

            return Ok(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var education = new DeleteEducationCommand { Id = id };

            var apiResponse = await _mediator.Send(education);

            return Ok(apiResponse);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Priorities(List<int> ids)
        {
            var priorities = new UpdatePrioritiesEducationCommand { Ids = ids };

            var apiResponse = await _mediator.Send(priorities);

            return Ok(apiResponse);
        }

        [HttpPut("{id}/{img}")]
        public async Task<ActionResult<BaseCommandResponse>> ChangeImg(int id , string img)
        {
            var changeImg = new ChangeEducationCommand { Id = id, Img = img };

            var apiResponse = await _mediator.Send(changeImg);

            return Ok(apiResponse);
        }
    }
}
