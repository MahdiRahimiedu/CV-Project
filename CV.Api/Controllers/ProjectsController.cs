using CV.Application.DTOs.Doings;
using CV.Application.DTOs.Projects;
using CV.Application.DTOs.Projectss;
using CV.Application.Features.Doings.Requests.Commands;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Features.Educations.Requests.Commands;
using CV.Application.Features.Projects.Requests.Commands;
using CV.Application.Features.Projects.Requests.Queries;
using CV.Application.Features.SocialNetWorks.Requests.Commands;
using CV.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> Get()
        {
            var projects = await _mediator.Send(new GetProjectListRequest());

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> Get(int id)
        {
            var project = await _mediator.Send(new GetProjectDetailRequest { Id = id });

            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreateProjectDto model)
        {
            var project = new CreateProjectCommand { CreateProjectDto = model };

            var apiResponse = await _mediator.Send(project);

            return Ok(apiResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Edit(int id, EditProjectDto model)
        {
            var project = new EditProjectCommand { EditProjectDto = model };

            var apiResponse = await _mediator.Send(project);

            return Ok(apiResponse);
        }
       
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var project = new DeleteProjectCommand { Id = id };

            var apiResponse = await _mediator.Send(project);

            return Ok(apiResponse);
        }


        [HttpDelete]
        public async Task<ActionResult<BaseCommandResponse>> Delete(List<int> ids)
        {
            var project = new DeleteAllProjectCommand { Ids = ids };

            var apiResponse = await _mediator.Send(project);

            return Ok(apiResponse);
        }
    }
}
