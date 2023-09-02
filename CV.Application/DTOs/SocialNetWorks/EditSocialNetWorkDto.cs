using CV.Application.DTOs.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.SocialNetWorks
{
    public class EditSocialNetWorkDto : BaseDto , ISocialNetWorkDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Icon { get; set; }
    }
}
