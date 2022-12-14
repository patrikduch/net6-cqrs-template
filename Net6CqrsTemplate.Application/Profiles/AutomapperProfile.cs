using AutoMapper;
using Net6CqrsTemplate.Application.Dtos;
using Net6CqrsTemplate.Application.Dtos.Value.Requests;
using Net6CqrsTemplate.Domain.Entities;

namespace Net6CqrsTemplate.Application.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ValueEntity, ValueItemDto>().ReverseMap();
            CreateMap<ValueEntity, InsertValueItemRequestDto>().ReverseMap();
            CreateMap<ValueEntity, UpdateValueItemRequestDto>().ReverseMap();
        }
    }
}
