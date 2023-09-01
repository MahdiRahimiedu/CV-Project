using CV.Application.DTOs.Favorites;
using CV.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.Favorites.Requests.Commands
{
    public class CreateFavoriteCommand : IRequest<BaseCommandResponse>
    {
        public CreateFavoriteDto CreateFavoriteDto { get; set; }
    }
}
