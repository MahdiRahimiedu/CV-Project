using CV.Application.DTOs.Doings;
using CV.Application.DTOs.SocialNetWorks;
using CV.Application.DTOs.SocialNetWorkss;
using CV.Application.Features.Doings.Requests.Commands;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Features.SocialNetWorks.Requests.Commands;
using CV.Application.Features.SocialNetWorks.Requests.Queries;
using CV.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/socialnetworks")]
    [ApiController]
    public class SocialNetWorksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialNetWorksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<SocialsNetWorkDto>>> Get()
        {
            var socialnetworks = await _mediator.Send(new GetSocialNetWorkListRequest());

            return Ok(socialnetworks);
            //return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SocialsNetWorkDto>> Get(int id)
        {
            var socialnetwork = await _mediator.Send(new GetSocialNetWorkDetailRequest { Id = id });

            return Ok(socialnetwork);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreateSocialNetWorkDto model)
        {
            var socialnetwork = new CreateSocialNetWorkCommand { CreateSocialNetWorkDto = model };

            var apiResponse = await _mediator.Send(socialnetwork);

            return Ok(apiResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Edit(int id, EditSocialNetWorkDto model)
        {
            var socialnetwork = new EditSocialNetWorkCommand { EditSocialNetWorkDto = model };

            var apiResponse = await _mediator.Send(socialnetwork);

            return Ok(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var socialnetwork = new DeleteSocialNewWorkCommand { Id = id };

            var apiResponse = await _mediator.Send(socialnetwork);

            return Ok(apiResponse);
        }


        [HttpDelete]
        public async Task<ActionResult<BaseCommandResponse>> Delete(List<int> ids)
        {
            var socialNetWork = new DeleteAllSocialNetWorkCommand { Ids = ids };

            var apiResponse = await _mediator.Send(socialNetWork);

            return Ok(apiResponse);
        }
    }
}
