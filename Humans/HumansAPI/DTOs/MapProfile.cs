using AutoMapper;
using HumansAPI.Models.Domain;

namespace HumansAPI.DTOs
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Human, CreateHumanRequest>().ReverseMap();
            CreateMap<Human, ReadHumanDTO>().ReverseMap();
            CreateMap<Human, UpdateHumanRequest>().ReverseMap();
            CreateMap<HumanConnection, ReadConnectedHumanDTO>().ReverseMap();
            CreateMap<HumanConnection, AddConnectedHumanRequest>().ReverseMap();
            CreateMap<Phone, AddPhoneRequest>().ReverseMap();
            CreateMap<Phone, ReadPhoneDTO>().ReverseMap();
            CreateMap<Phone, UpdatePhoneRequest>().ReverseMap();

        }
    }
}
