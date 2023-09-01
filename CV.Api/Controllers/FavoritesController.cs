using CV.Application.DTOs.Doings;
using CV.Application.DTOs.Favorites;
using CV.Application.DTOs.Favoritess;
using CV.Application.Features.Doings.Requests.Commands;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Features.Favorites.Requests.Commands;
using CV.Application.Features.Favorites.Requests.Queries;
using CV.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CV.Api.Controllers
{
    [Route("api/favorites")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoritesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<FavoriteDto>>> Get()
        {
            var favorites = await _mediator.Send(new GetFavoriteListRequest());

            return Ok(favorites);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FavoriteDto>> Get(int id)
        {
            var favorite = await _mediator.Send(new GetFavoriteDetailRequest{ Id = id });

            return Ok(favorite);
        }

        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreateFavoriteDto model)
        {
            var favorite = new CreateFavoriteCommand { CreateFavoriteDto = model };

            var apiResponse = await _mediator.Send(favorite);

            return Ok(apiResponse);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Edit(int id, EditFavoriteDto model)
        {
            var favorite = new EditFavoriteCommand { EditFavoriteDto = model };

            var apiResponse = await _mediator.Send(favorite);

            return Ok(apiResponse);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var favorite = new DeleteFavoriteCommand { Id = id };

            var apiResponse = await _mediator.Send(favorite);

            return Ok(apiResponse);
        }
    }
}
