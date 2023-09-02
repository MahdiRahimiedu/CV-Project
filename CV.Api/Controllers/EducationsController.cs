﻿using CV.Application.DTOs.Educations;
using CV.Application.Features.Educations.Requests.Commands;
using CV.Application.Features.Educations.Requests.Queries;
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
            var education = await _mediator.Send(new GetEducationDetailRequest());

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
        public async Task<ActionResult<BaseCommandResponse>> Edit(int id , EditEducationDto model)
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
    }
}
