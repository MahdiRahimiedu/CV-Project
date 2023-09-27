using CV.Application.DTOs.AboutUs;
using CV.Application.DTOs.Doings;
using CV.Application.Features.AboutUs.Requests.Commands;
using CV.Application.Features.AboutUs.Requests.Queries;
using CV.Application.Features.Doings.Requests.Commands;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/aboutus")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutUsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<AboutUsDto>>> Get()
        {
            var doings = await _mediator.Send(new GetAboutUsListRequest());

            return Ok(doings);
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AboutUsDto>> Get(int id)
        {
            var doing = await _mediator.Send(new GetAboutUsDetailRequest { Id = id });

            return Ok(doing);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(AboutUsDto model)
        {
            var doing = new CreateAboutUsCommand { CreateAboutUsDto = model };

            var apiResponse = await _mediator.Send(doing);

            return Ok(apiResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Edit(int id, AboutUsDto model)
        {
            var doing = new EditAboutUsCommand { UpdateAboutUsDto = model };

            var apiResponse = await _mediator.Send(doing);

            return Ok(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var doing = new DeleteAboutUsCommand { Id = id };

            var apiResponse = await _mediator.Send(doing);

            return Ok(apiResponse);
        }

        
    }
}
