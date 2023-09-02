using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Skills
{
    public class CreateSkillDto : ISkillDto
    {
        public string Name { get; set; }
        public string SkillValue { get; set; }
    }
}
