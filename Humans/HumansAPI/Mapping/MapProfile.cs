using AutoMapper;
using HumansAPI.DTOs;
using HumansAPI.Models.Domain;
using HumansAPI.Requests;

namespace HumansAPI.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Human, AddHumanRequest>().ReverseMap();
            CreateMap<Human, ReadHumanDTO>().ForPath(x=>x.City.Id,y=>y.MapFrom(d=>d.CityId)).ReverseMap();
            CreateMap<Human, UpdateHumanRequest>().ReverseMap();
            CreateMap<HumanConnection, ReadConnectedHumanDTO>().ReverseMap();
            CreateMap<HumanConnection, AddConnectedHumanRequest>().ReverseMap();
            CreateMap<Phone, AddPhoneRequest>().ReverseMap();
            CreateMap<Phone, ReadPhoneDTO>().ReverseMap();
            CreateMap<Phone, UpdatePhoneRequest>().ReverseMap();
            CreateMap<City, ReadCityDTO>().ReverseMap();
            CreateMap<City, UpdateCityRequest>().ReverseMap();
            CreateMap<City, AddCityRequest>().ReverseMap();

        }
    }

}
