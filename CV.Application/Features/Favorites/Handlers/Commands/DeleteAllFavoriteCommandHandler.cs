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
    public class DeleteAllFavoriteCommandHandler : IRequestHandler<DeleteAllFavoriteCommand, BaseCommandResponse>
    {
        public IFavorioteRepository _favoriteRepository { get; set; }

        public DeleteAllFavoriteCommandHandler(IFavorioteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteAllFavoriteCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            if (!await _favoriteRepository.ExistListAsync(request.Ids))
            {
                response.Success = false;
                response.Message = "deleted faild";
                return response;
            }
            await _favoriteRepository.DeleteAllAsync(request.Ids);
            response.Success = true;
            response.Message = "deleted seccessful";
            return response;
        }
    }
}
