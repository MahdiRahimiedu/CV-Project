using AutoMapper;
using CV.Application.DTOs.Doings;
using CV.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doing, DoingDto>().ReverseMap();

        }
    }
}
