using CV.Application.Contracts.Persistence;
using CV.Application.Features.Favorites.Requests.Commands;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Favorites.Handlers.Commands
{
    public class DeleteFavoriteCommandHandler : IRequestHandler<DeleteFavoriteCommand , BaseCommandResponse>
    {
        private readonly IFavorioteRepository _favoriteRepo;

        public DeleteFavoriteCommandHandler(IFavorioteRepository favoriteRepo)
        {
            _favoriteRepo = favoriteRepo;
        }

        public async Task<BaseCommandResponse> Handle(DeleteFavoriteCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var favorite = await _favoriteRepo.GetByIdAsync(request.Id);

            if (favorite == null)
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }

            await _favoriteRepo.DeleteAsync(favorite);

            response.Success = true;
            response.Message = "deleted seccessful";
            return response;
        }
    }
}
