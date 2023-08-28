using CV.Application.DTOs.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Educations
{
    public class EducationDto : BaseDto , IEducationDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string? Img { get; set; }
        public int Priorty { get; set; }
    }
}
