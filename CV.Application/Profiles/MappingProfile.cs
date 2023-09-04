using AutoMapper;
using CV.Application.DTOs.ContactMes;
using CV.Application.DTOs.Doings;
using CV.Application.DTOs.Educations;
using CV.Application.DTOs.EmploymentHistories;
using CV.Application.DTOs.Favorites;
using CV.Application.DTOs.Favoritess;
using CV.Application.DTOs.Projects;
using CV.Application.DTOs.Projectss;
using CV.Application.DTOs.Services;
using CV.Application.DTOs.Servicess;
using CV.Application.DTOs.Skills;
using CV.Application.DTOs.Skillss;
using CV.Application.DTOs.SocialNetWorks;
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
            CreateMap<ContactMe, CreateContactMeDto>().ReverseMap();
            CreateMap<ContactMe, EditContactMeDto>().ReverseMap();
            CreateMap<ContactMe, ChangeNoteContactMeDto>().ReverseMap();

            CreateMap<Doing, DoingDto>().ReverseMap();
            CreateMap<Doing, CreateDoingDto>().ReverseMap();
            CreateMap<Doing, EditDoingDto>().ReverseMap();

            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<Education, CreateEducationDto>().ReverseMap();
            CreateMap<Education, EditEducationDto>().ReverseMap();

            CreateMap<EmploymentHistory, EmploymentHistoryDto>().ReverseMap();
            CreateMap<EmploymentHistory, CreateEmploymentHistoryDto>().ReverseMap();
            CreateMap<EmploymentHistory, EditEmploymentHistoryDto>().ReverseMap();

            CreateMap<Favorite, FavoriteDto>().ReverseMap();
            CreateMap<Favorite, CreateFavoriteDto>().ReverseMap();
            CreateMap<Favorite, EditFavoriteDto>().ReverseMap();

            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Project, CreateProjectDto>().ReverseMap();
            CreateMap<Project, EditProjectDto>().ReverseMap();

            CreateMap<Servic, ServicDto>().ReverseMap();
            CreateMap<Servic, CreateServicDto>().ReverseMap();
            CreateMap<Servic, EditServicDto>().ReverseMap();

            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<Skill, CreateSkillDto>().ReverseMap();
            CreateMap<Skill, EditSkillDto>().ReverseMap();

            CreateMap<SocialsNetWork, SocialsNetWorkDto>().ReverseMap();
            CreateMap<SocialsNetWork, CreateSocialNetWorkDto>().ReverseMap();
            CreateMap<SocialsNetWork, EditSocialNetWorkDto>().ReverseMap();

           


        }
    }
}
