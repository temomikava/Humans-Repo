using AutoMapper;
using HumansAPI.Models.Domain;

namespace HumansAPI.DTOs
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Human, CreateHumanRequest>().ReverseMap();
            CreateMap<Human, ReadHumanRequest>().ReverseMap();
            CreateMap<Human, UpdateHumanRequest>().ReverseMap();
            CreateMap<HumanConnection, ReadConnectedHumanRequest>().ReverseMap();
            CreateMap<HumanConnection, UpdateConnectedHumanRequest>().ReverseMap();
            CreateMap<HumanConnection, AddConnectedHumanRequest>().ReverseMap();
            CreateMap<Phone, AddPhoneRequest>().ReverseMap();
            CreateMap<Phone, ReadPhoneDTO>().ReverseMap();
            CreateMap<Phone, UpdatePhoneRequest>().ReverseMap();

        }
    }
}
