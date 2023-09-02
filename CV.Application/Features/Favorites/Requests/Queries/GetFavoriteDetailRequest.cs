using CV.Application.DTOs.Favoritess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Favorites.Requests.Queries
{
    public class GetFavoriteDetailRequest : IRequest<FavoriteDto>
    {
        public int Id { get; set; }
    }
}
