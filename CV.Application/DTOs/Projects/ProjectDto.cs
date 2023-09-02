using CV.Application.DTOs.Command;
using CV.Application.DTOs.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Projectss
{
    public class ProjectDto : BaseDto , IProjectDto
    {
        public string Name { get; set; }
        public string Applicant { get; set; }
        public string Date { get; set; }
        public string Img { get; set; }
    }
}
