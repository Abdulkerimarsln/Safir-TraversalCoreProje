using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using DTOLayer.DTOs;
using DTOLayer.DTOs.AnnouncementDTO;
using DTOLayer.DTOs.CityDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;

namespace TraversalCoreProje.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile() 
        {
            CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();

            CreateMap<AppUserRegisterDTO, AppUser>().ReverseMap();

            CreateMap<AppUserLoginDTO, AppUser>().ReverseMap();

            CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();

            CreateMap<AnnouncementUpdateDTO, Announcement>().ReverseMap();

            CreateMap<SendMessageDto,ContactUs>().ReverseMap();

        }
    }
}
