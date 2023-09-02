using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Services
{
    public interface IServicDto
    {
        public string Name { get; set; }
        public string? Icon { get; set; }
    }
}
