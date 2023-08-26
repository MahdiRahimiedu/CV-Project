using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Doings;
using CV.Application.DTOs.Favoritess;
using CV.Application.Features.Doings.Requests.Queries;
using CV.Application.Features.Favorites.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Favorites.Handlers.Queries
{
    public class GetFavoriteListRequestHandlers : IRequestHandler<GetFavoriteListRequest, List<FavoriteDto>>
    {
        private readonly IMapper _mapper;
        private readonly IFavorioteRepository _favoriteRepo;

        public GetFavoriteListRequestHandlers(IMapper mapper, IFavorioteRepository favoriteRepo)
        {
            _mapper = mapper;
            _favoriteRepo = favoriteRepo;
        }

        public async Task<List<FavoriteDto>> Handle(GetFavoriteListRequest request, CancellationToken cancellationToken)
        {
            var favorit = await _favoriteRepo.GetAllAsync();
            return _mapper.Map<List<FavoriteDto>>(favorit);
        }
    }

}
