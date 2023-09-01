using CV.Application.DTOs.ContactMes;
using CV.Application.Features.ContactMes.Requests.Commands;
using CV.Application.Features.ContactMes.Requests.Queries;
using CV.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/contactmes")]
    [ApiController]
    public class ContactMesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactMesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactMeDto>>> Get()
        {
            var contactMes = await _mediator.Send(new GetContactMeListRequest());

            return Ok(contactMes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactMeDto>> Get(int id)
        {
            var contactMe = await _mediator.Send(new GetContactMeDetailRequest { Id = id });

            return Ok(contactMe);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> create(CreateContactMeDto model)
        {
            var contactMe = new CreateContactMeCommand { CreateContactMeDto = model };

            var apiResponse = await _mediator.Send(contactMe);

            return Ok(apiResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Edit(int id, EditContactMeDto model)
        {
            var contactMe = new EditContactMeCommand { EditContactMeDto = model };

            var apiResponse = await _mediator.Send(contactMe);

            return Ok(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var contactMe = new DeleteContactMeCommand { Id = id };

            var apiResponse = await _mediator.Send(contactMe);

            return Ok(apiResponse);
        }
    }
}
