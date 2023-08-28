using CV.Application.DTOs.Command;
using CV.Application.DTOs.Favorites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Favoritess
{
    public class FavoriteDto : BaseDto , IFavoriteDto
    {
        public string Name { get; set; }
        public string? Detail { get; set; }
    }
}
