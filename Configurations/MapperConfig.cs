using AutoMapper;
using Session2.Models;

namespace Session2.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ProjectDto, ProjectDto>().ReverseMap();

        }
    }
}
