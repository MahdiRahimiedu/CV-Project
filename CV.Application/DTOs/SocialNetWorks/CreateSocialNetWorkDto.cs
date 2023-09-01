﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.DTOs.SocialNetWorks
{
    public class CreateSocialNetWorkDto : ISocialNetWorkDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Icon { get; set; }
    }
}
