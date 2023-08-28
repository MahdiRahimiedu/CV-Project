using CV.Application.DTOs.Favoritess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Favorites.Validators
{
    public class FavoriteDtoValidator : AbstractValidator<FavoriteDto>
    {
        public FavoriteDtoValidator()
        {
            Include(new IFavoriteDtoValidator());
        }
    }
}
