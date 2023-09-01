using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Favorites
{
    public class CreateFavoriteDto : IFavoriteDto
    {
        public string Name { get; set; }
        public string? Detail { get; set; }
    }
}
