using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.Skills
{
    public interface ISkillDto
    {
        public string Name { get; set; }
        public string SkillValue { get; set; }
        public bool IsActive { get; set; }

    }
}
