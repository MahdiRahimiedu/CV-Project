using CV.Application.DTOs.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Favorites
{
    public interface IFavoriteDto
    {
        public string Name { get; set; }
        public string? Detail { get; set; }
    }
}
