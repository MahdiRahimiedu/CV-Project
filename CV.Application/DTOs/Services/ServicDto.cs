using CV.Application.DTOs.Command;
using CV.Application.DTOs.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Servicess
{
    public class ServicDto : BaseDto , IServicDto
    {
        public string Name { get; set; }
        public string? Icon { get; set; }
        public int Priority { get; set; }
    }
}
