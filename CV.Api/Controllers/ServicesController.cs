﻿using CV.Application.DTOs.Doings;
using CV.Application.DTOs.Services;
using CV.Application.DTOs.Servicess;
using CV.Application.Features.Doings.Requests.Commands;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Features.Educations.Requests.Commands;
using CV.Application.Features.Services.Requests.Commands;
using CV.Application.Features.Services.Requests.Queries;
using CV.Application.Features.Skills.Requests.Commands;
using CV.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServicDto>>> Get()
        {
            var services = await _mediator.Send(new GetServicListRequest());

            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServicDto>> Get(int id)
        {
            var servic = await _mediator.Send(new GetServiceDetailRequest { Id = id });

            return Ok(servic);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreateServicDto model)
        {
            var servic = new CreateServicCommand { CreateServicDto = model };

            var apiResponse = await _mediator.Send(servic);

            return Ok(apiResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Edit(int id, EditServicDto model)
        {
            var servic = new EditServicCommand { EditServicDto = model };

            var apiResponse = await _mediator.Send(servic);

            return Ok(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var servic = new DeleteServicCommand { Id = id };

            var apiResponse = await _mediator.Send(servic);

            return Ok(apiResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<BaseCommandResponse>> Delete(List<int> ids)
        {
            var servic = new DeleteAllServicCommand { Ids = ids };

            var apiResponse = await _mediator.Send(servic);

            return Ok(apiResponse);
        }

        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse>> Priorities(List<int> ids)
        {
            var priorities = new UpdatePrioritiesServicCommand { Ids = ids };

            var apiResponse = await _mediator.Send(priorities);

            return Ok(apiResponse);
        }
    }
}
