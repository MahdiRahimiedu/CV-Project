﻿using CV.Application.DTOs.Doings;
using CV.Application.DTOs.Skills;
using CV.Application.DTOs.Skillss;
using CV.Application.Features.Doings.Requests.Commands;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Features.Skills.Requests.Commands;
using CV.Application.Features.Skills.Requests.Queries;
using CV.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<SkillDto>>> Get()
        {
            var skills = await _mediator.Send(new GetSkillListRequest());

            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SkillDto>> Get(int id)
        {
            var skill = await _mediator.Send(new GetSkillDetailRequest { Id = id });

            return Ok(skill);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreateSkillDto model)
        {
            var skill = new CreateSkillCommand { CreateSkillDto = model };

            var apiResponse = await _mediator.Send(skill);

            return Ok(apiResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Edit(int id, EditSkillDto model)
        {
            var skill = new EditSkillCommand { EditSkillDto = model };

            var apiResponse = await _mediator.Send(skill);

            return Ok(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var skill = new DeleteSkillCommand { Id = id };

            var apiResponse = await _mediator.Send(skill);

            return Ok(apiResponse);
        }
    }
}
