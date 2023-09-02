using CV.Application.DTOs.Doings;
using CV.Application.Features.Doings.Requests.Commands;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Response;
using CV.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CV.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/doings")]
    [ApiController]
    public class DoingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<DoingDto>>> Get()
        {
            var doings = await _mediator.Send(new GetDoingListRequest()); 

            return Ok(doings);
            //return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoingDto>> Get(int id)
        {
            var doing = await _mediator.Send(new GetDoingDetailRequest { Id = id});

            return Ok(doing);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreateDoingDto model)
        {
            var doing = new CreateDoingCommand { CreateDoingDto = model };

            var apiResponse = await _mediator.Send(doing);

            return Ok(apiResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Edit(int id , EditDoingDto model)
        {
            var doing = new EditDoingCommand { EditDoingDto = model };

            var apiResponse = await _mediator.Send(doing);

            return Ok(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var doing = new DeleteDoingCommand { Id = id };

            var apiResponse = await _mediator.Send(doing);

            return Ok(apiResponse);
        }

    }
}
