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
            CreateMap<ReciboForCreationDto, Recibo>();
            CreateMap<DetalleReciboForPostDto, DetalleRecibo>();
            CreateMap<Recibo, ReciboToListDto>();
            CreateMap<Recibo, ReciboToDetailDto>();
            CreateMap<DetalleRecibo, DetalleReciboForDetailDto>()
            .ForMember(dest => dest.Material, opt => opt.MapFrom(src => src.Material.ClaveMaterial))
             .ForMember(dest => dest.Unidad, opt => opt.MapFrom(src => src.UnidadMedida.Unidad));
            CreateMap<ExistenciaMaterial, ExistenciaMaterialToListDto>()
            .ForMember(dest => dest.UnidadMedida, opt => opt.MapFrom(src => src.Material.UnidadMedida.Unidad))
            .ForMember(dest => dest.Cliente, opt => opt.MapFrom(src => src.Material.Cliente.Nombre));

        }
    }
}