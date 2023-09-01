using CV.Application.DTOs.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Services
{
    public class EditServicDto : BaseDto , IServicDto
    {
        public string Name { get; set; }
        public string? Icon { get; set; }
    }
}
