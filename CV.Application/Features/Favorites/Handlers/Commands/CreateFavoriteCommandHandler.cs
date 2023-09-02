using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Favorites.Validators;
using CV.Application.Features.Favorites.Requests.Commands;
using CV.Application.Response;
using CV.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Favorites.Handlers.Commands
{
    public class CreateFavoriteCommandHandler : IRequestHandler<CreateFavoriteCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFavorioteRepository _favoriteioteRepository;

        public CreateFavoriteCommandHandler(IMapper mapper, IFavorioteRepository favoriteioteRepository)
        {
            _mapper = mapper;
            _favoriteioteRepository = favoriteioteRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateFavoriteCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFavoriteDtoValidator();
            var result = await validator.ValidateAsync(request.CreateFavoriteDto);

            if(!result.IsValid)
            {
                response.Success = false;
                response.Message = "creating failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            var favorit = _mapper.Map<Favorite>(request.CreateFavoriteDto);
            favorit = await _favoriteioteRepository.AddAsync(favorit);
            response.Success = true;
            response.Message = "creating Successful";
            response.Id = favorit.Id;
            return response;
        }
    }
}
