using CV.Application.DTOs.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Projects
{
    public class EditProjectDto : BaseDto , IProjectDto
    {
        public string Name { get; set; }
        public string Applicant { get; set; }
        public string Date { get; set; }
        public string Img { get; set; }
    }
}
