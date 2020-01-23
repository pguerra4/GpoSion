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
            .ForMember(dest => dest.LocalidadId, opt => opt.MapFrom(src => src.Viajero.LocalidadId));
            CreateMap<ExistenciaMaterial, ExistenciaMaterialToListDto>()
            .ForMember(dest => dest.UnidadMedida, opt => opt.MapFrom(src => src.Material.UnidadMedida.Unidad))
            .ForMember(dest => dest.NumerosParte, opt => opt.MapFrom(src => src.Material.MaterialNumerosParte.Select(mnp => mnp.NoParte)));
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
            CreateMap<MaterialNumeroParte, MaterialNumeroParteToListDto>().ReverseMap();
            CreateMap<NumeroParte, NumeroParteToListDto>();
            CreateMap<NumeroParteToCreateDto, NumeroParte>();
            CreateMap<NumeroParte, NumeroParteForDetailDto>()
            .ForMember(dest => dest.Materiales, opt => opt.MapFrom(src => src.MaterialesNumeroParte))
            .ForMember(dest => dest.Moldes, opt => opt.MapFrom(src => src.MoldesNumeroParte.Select(mnp => mnp.Molde)));
            CreateMap<Moldeadora, MoldeadoraToListDto>()
            .ForMember(dest => dest.NumerosParte, opt => opt.MapFrom(src => src.MoldeadoraNumerosParte.Select(mnp => mnp.NoParte)));
            CreateMap<MoldeadoraToCreateDto, Moldeadora>();
            CreateMap<TipoMaterialToCreateDto, TipoMaterial>();
            CreateMap<TipoMaterialToEditDto, TipoMaterial>();
            CreateMap<ProduccionToCreateDto, Produccion>();
            CreateMap<ProduccionNumeroParteToCreateDto, ProduccionNumeroParte>().ReverseMap();
            CreateMap<Produccion, ProduccionForDetailDto>();
            CreateMap<OrdenCompraDetalle, OrdenCompraDetalleToListDto>()
             .ForMember(dest => dest.NumeroParteNoParte, opt => opt.MapFrom(src => src.NoParte))
             .ReverseMap()
            .ForMember(dest => dest.NoParte, opt => opt.MapFrom(src => src.NumeroParteNoParte));
            CreateMap<OrdenCompra, OrdenCompraToListDto>().ReverseMap();
            CreateMap<ClienteToCreateDto, Cliente>();
            CreateMap<ClienteForPutDto, Cliente>();
            CreateMap<Proveedor, ProveedorForListDto>();
            CreateMap<Proveedor, ProveedorForDetailDto>();
            CreateMap<ProveedorToCreateDto, Proveedor>();
            CreateMap<ProveedorForPutDto, Proveedor>();
            CreateMap<MovimientoProductoToCreateDto, MovimientoProducto>();
            CreateMap<MovimientoProductoForPutDto, MovimientoProducto>();
            CreateMap<MovimientoProducto, MovimientoProductoToListDto>();
            CreateMap<DetalleEmbarqueToCreateDto, DetalleEmbarque>();
            CreateMap<EmbarqueToCreateDto, Embarque>();
            CreateMap<DetalleEmbarque, DetalleEmbarqueToListDto>();
            CreateMap<Embarque, EmbarqueToListDto>();
            CreateMap<OrdenCompraProveedorDetalle, OrdenCompraProveedorDetalleToListDto>()
             .ForMember(dest => dest.MaterialClaveMaterial, opt => opt.MapFrom(src => src.Material.ClaveMaterial))
             .ReverseMap();
            CreateMap<OrdenCompraProveedor, OrdenCompraProveedorToListDto>().ReverseMap();
            CreateMap<Localidad, LocalidadToListDto>();
            CreateMap<LocalidadToCreateDto, Localidad>();
            CreateMap<LocalidadToEditDto, Localidad>();
            CreateMap<User, UserForListDto>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserToEditDto, User>();
        }
    }
}