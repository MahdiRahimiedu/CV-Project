using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Favoritess;
using CV.Application.Features.Favorites.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Favorites.Handlers.Queries
{
    public class GetFavoriteDetailRequestHandler : IRequestHandler<GetFavoriteDetailRequest , FavoriteDto>
    {
        private readonly IMapper _mapper;
        private readonly IFavorioteRepository _favoriteioteRepository;

        public GetFavoriteDetailRequestHandler(IMapper mapper, IFavorioteRepository favoriteioteRepository)
        {
            _mapper = mapper;
            _favoriteioteRepository = favoriteioteRepository;
        }

        public async Task<FavoriteDto> Handle(GetFavoriteDetailRequest request, CancellationToken cancellationToken)
        {
            var result = await _favoriteioteRepository.GetByIdAsync(request.Id);
            return _mapper.Map<FavoriteDto>(result);S
        }
    }
}
