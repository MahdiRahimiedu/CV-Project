﻿using CV.Application.DTOs.SocialNetWorkss;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Features.SocialNetWorks.Requests.Queries
{
    public class GetSocialNetWorkDetailRequest : IRequest<SocialsNetWorkDto>
    {
        public int Id { get; set; }
    }
}
