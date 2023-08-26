using AutoMapper;
using CV.Application.DTOs.ContactMes;
using CV.Application.DTOs.Doings;
using CV.Application.DTOs.Educations;
using CV.Application.DTOs.EmploymentHistories;
using CV.Application.DTOs.Favoritess;
using CV.Application.DTOs.Projectss;
using CV.Application.DTOs.Servicess;
using CV.Application.DTOs.Skillss;
using CV.Application.DTOs.SocialNetWorkss;
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
            CreateMap<ContactMe, ContactMeDto>().ReverseMap();
            CreateMap<Doing, DoingDto>().ReverseMap();
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<EmploymentHistory, EmploymentHistoryDto>().ReverseMap();
            CreateMap<Favorite, FavoriteDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Servic, ServicDto>().ReverseMap();
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<SocialsNetWork, SocialsNetWorkDto>().ReverseMap();

        }
    }
}
