using AutoMapper;
using CV.Application.Contracts.Persistence;
using CV.Application.DTOs.Favorites.Validators;
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
    public class EditFavoriteCommandHandler : IRequestHandler<EditFavoriteCommand , BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IFavorioteRepository _favoriteRepository;

        public EditFavoriteCommandHandler(IMapper mapper, IFavorioteRepository favoriteRepository)
        {
            _mapper = mapper;
            _favoriteRepository = favoriteRepository;
        }

        public async Task<BaseCommandResponse> Handle(EditFavoriteCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new EditFavoriteDtoValidator();
            var result = await validator.ValidateAsync(request.EditFavoriteDto);

            if (!result.IsValid)
            {
                response.Success = false;
                response.Message = "edited failld";
                response.Erorrs = result.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var favorite = await _favoriteRepository.GetByIdAsync(request.EditFavoriteDto.Id);

            if (favorite == null)
            {
                response.Success = false;
                response.Message = "edited failld";
                return response;
            }

            _mapper.Map(request.EditFavoriteDto, favorite);
            await _favoriteRepository.UpdateAsync(favorite);

            response.Success = true;
            response.Message = "edited successful";
            return response;
        }
    }
}
