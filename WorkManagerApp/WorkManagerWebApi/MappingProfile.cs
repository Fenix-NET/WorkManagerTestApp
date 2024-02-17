using AutoMapper;
using Core.Entities.Dtos;
using Core.Entities.Models;

namespace WorkManagerWebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmloyeeDto>().ForMember(dest =>
                dest.Department, opt =>
                opt.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.IsBusy, opt => 
                    opt.MapFrom(src => src.Busy));
        }
    }
}
