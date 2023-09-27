using CV.Application.DTOs.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.AboutUs
{
    public class AboutUsDto:BaseDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? AbouteMe { get; set; }
        public string? CupCuffee { get; set; }
        public string? CompletedProject { get; set; }
    }
}
