using AutoMapper;
using GpoSion.API.Dtos;
using GpoSion.API.Models;

namespace GpoSion.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Cliente, ClienteForDetailDto>();
            CreateMap<Cliente, ClienteForListDto>();
            CreateMap<Material, MaterialforPostDto>();
        }
    }
}