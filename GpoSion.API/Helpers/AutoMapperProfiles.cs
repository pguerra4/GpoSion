using System.Linq;
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
            CreateMap<MaterialforPostDto, Material>();
            CreateMap<Material, MaterialtoListDto>();
            CreateMap<ReciboForCreationDto, Recibo>();
            CreateMap<DetalleReciboForPostDto, DetalleRecibo>();
            CreateMap<Recibo, ReciboToListDto>();
            CreateMap<Recibo, ReciboToDetailDto>();
            CreateMap<DetalleRecibo, DetalleReciboForDetailDto>()
            .ForMember(dest => dest.Material, opt => opt.MapFrom(src => src.Material.ClaveMaterial))
            .ForMember(dest => dest.Unidad, opt => opt.MapFrom(src => src.UnidadMedida.Unidad))
            .ForMember(dest => dest.Localidad, opt => opt.MapFrom(src => src.Viajero.Localidad));
            CreateMap<ExistenciaMaterial, ExistenciaMaterialToListDto>()
            .ForMember(dest => dest.UnidadMedida, opt => opt.MapFrom(src => src.Material.UnidadMedida.Unidad));
            CreateMap<MovimientoMaterial, MovimientoMaterialForViajeroDetailDto>();
            CreateMap<Viajero, ViajeroForDetailDto>();
            CreateMap<Viajero, ViajeroToListDto>();
            CreateMap<ViajeroForPutDto, Viajero>();
            CreateMap<RequerimientoMaterialMaterialForCreationDto, RequerimientoMaterialMaterial>();
            CreateMap<RequerimientoforCreationDto, RequerimientoMaterial>();
            CreateMap<RequerimientoMaterialMaterial, RequerimientoMaterialMaterialForDetailDto>();
            CreateMap<RequerimientoMaterial, RequerimientoMaterialForDetailDto>();
            CreateMap<Molde, MoldeToListDto>();
            CreateMap<Molde, MoldeForDetailDto>()
            .ForMember(dest => dest.NumerosParte, opt => opt.MapFrom(src => src.MoldeNumerosParte.Select(mnp => mnp.NoParte)));
            CreateMap<MoldeForCreationDto, Molde>();
            CreateMap<MoldeForPutDto, Molde>();
            CreateMap<NumeroParte, NumeroParteToListDto>();
            CreateMap<NumeroParteToCreateDto, NumeroParte>();
            CreateMap<NumeroParte, NumeroParteForDetailDto>()
            .ForMember(dest => dest.Materiales, opt => opt.MapFrom(src => src.MaterialesNumeroParte.Select(mnp => mnp.Material)))
            .ForMember(dest => dest.Moldes, opt => opt.MapFrom(src => src.MoldesNumeroParte.Select(mnp => mnp.Molde)));
            CreateMap<Moldeadora, MoldeadoraToListDto>()
            .ForMember(dest => dest.NumerosParte, opt => opt.MapFrom(src => src.MoldeadoraNumerosParte.Select(mnp => mnp.NoParte)));
            CreateMap<MoldeadoraToCreateDto, Moldeadora>();
            CreateMap<TipoMaterialToCreateDto, TipoMaterial>();
            CreateMap<TipoMaterialToEditDto, TipoMaterial>();
            CreateMap<ProduccionToCreateDto, Produccion>();
            CreateMap<ProduccionNumeroParteToCreateDto, ProduccionNumeroParte>().ReverseMap();
            CreateMap<Produccion, ProduccionForDetailDto>();
        }
    }
}