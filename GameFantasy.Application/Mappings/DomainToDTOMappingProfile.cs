using AutoMapper;
using GameFantasy.Application.DTOs;
using GameFantasy.Domain.Entities;

namespace GameFantasy.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Time, TimeDTO>().ReverseMap();
            CreateMap<Time, TimeUpdateDTO>().ReverseMap();
        }
    }
}
