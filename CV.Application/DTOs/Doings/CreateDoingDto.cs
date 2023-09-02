using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Doings
{
    public class CreateDoingDto : IDoingDto
    {
        public string Title { get; set; }
        public string? Location { get; set; }
        public string Detail { get; set; }
    }
}
