using CV.Application.DTOs.Command;
using CV.Application.DTOs.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Skillss
{
    public class SkillDto : BaseDto , ISkillDto
    {
        public string Name { get; set; }
        public string SkillValue { get; set; }
        public int Priority { get; set; }
        public bool IsActive { get; set; }

    }
}
