

using AutoMapper;
using CV.Application.DTOs.ContactMes;
using CV.Site.ViewModels.ContactMe;

namespace CV.Site
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region ContactMe
            CreateMap<ContactMeDto, ContactMeVM>().ReverseMap();
            CreateMap<CreateContactMeDto, CreateContactMeVM>().ReverseMap();
            CreateMap<EditContactMeDto, UpdateContactMeVM>().ReverseMap();
            CreateMap<ChangeNoteContactMeDto, ChangeNoteContactMeVM>().ReverseMap();
            #endregion

        }
    }
}
