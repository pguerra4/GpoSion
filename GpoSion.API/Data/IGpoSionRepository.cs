using System.Collections.Generic;
using System.Threading.Tasks;
using GpoSion.API.Helpers;
using GpoSion.API.Models;

namespace GpoSion.API.Data
{
    public interface IGpoSionRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAll();

        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente> GetCliente(int id);

        Task<IEnumerable<UnidadMedida>> GetUnidadesMedida();
        Task<UnidadMedida> GetUnidadMedida(int id);

        Task<IEnumerable<Area>> GetAreas();
        Task<Area> GetArea(int id);
        Task<IEnumerable<ExistenciaMaterial>> GetExistencias();
        Task<ExistenciaMaterial> GetExistencia(int id);
        Task<ExistenciaMaterial> GetExistenciaPorAreaMaterial(int areaId, int materialId);

        Task<IEnumerable<Material>> GetMateriales(MaterialParams materialParams);
        Task<Material> GetMaterial(int id);
        Task<Material> GetMaterialByClienteNombre(int clienteId, string nombre);
        Task<IEnumerable<Viajero>> GetViajerosPorMaterial(int materialId);


        Task<IEnumerable<Recibo>> GetRecibos();
        Task<Recibo> GetRecibo(int id);

        Task<IEnumerable<MovimientoMaterial>> GetMovimientoMateriales(RetornoMaterialParams retornoParams);
        Task<MovimientoMaterial> GetMovimientoMaterial(int id);

        Task<IEnumerable<MovimientoMaterial>> GetMovimientoMaterialesPorViajero(int viajero);

        Task<Viajero> GetViajero(int viajeroId);

        Task<IEnumerable<Turno>> GetTurnos();

        Task<IEnumerable<ExistenciaMaterial>> GetExistenciasEnAlmacen();

        Task<IEnumerable<RequerimientoMaterial>> GetRequerimientosMaterial(RequerimientoParams requerimientoParams);

        Task<RequerimientoMaterial> GetRequerimientoMaterial(int id);

        Task<bool> ExisteRecibo(int noRecibo);

        Task<DetalleRecibo> GetDetalleRecibo(int Id);

        Task<IEnumerable<Viajero>> GetViajeros(ViajeroParams viajeroParams);

        Task<IEnumerable<Molde>> GetMoldes(MoldesParams moldesParams);

        Task<Molde> GetMolde(int Id);

        Task<OrdenCompra> GetOrdenCompra(long Id);

        Task<IEnumerable<OrdenCompra>> GetOrdenesCompra();

        Task<NumeroParte> GetNumeroParte(string NoParte);

        Task<IEnumerable<NumeroParte>> GetNumerosParte(NumeroParteParams numeroParteParams);

        Task<Moldeadora> GetMoldeadora(int Id);

        Task<IEnumerable<Moldeadora>> GetMoldeadoras();

        Task<TipoMaterial> GetTipoMaterial(int id);

        Task<IEnumerable<TipoMaterial>> GetTiposMaterial();

        Task<bool> ExisteTipoMaterial(string tipo);

        Task<bool> ExisteMaterial(string material, int id);

        Task<bool> ExisteNumeroParte(string NoParte);

        Task<IEnumerable<Proveedor>> GetProveedores();

        Task<Proveedor> GetProveedor(int id);

        Task<OrdenCompraDetalle> GetOrdenCompraDetalle(int id);

        Task<bool> ExisteOrdenCompraActiva(string noParte);

        Task<IEnumerable<MotivoTiempoMuerto>> GetMotivosTiempoMuerto();
        Task<MotivoTiempoMuerto> GetMotivoTiempoMuerto(int id);

        Task<MovimientoProducto> GetMovimientoProducto(int id);

        Task<IEnumerable<MovimientoProducto>> GetMovimientosProducto(MovimientoProductoParams movimientoParams);

        Task<Embarque> GetEmbarque(int id);

        Task<IEnumerable<Embarque>> GetEmbarques(EmbarqueParams embarqueParams);

        Task<ExistenciaProducto> GetExistenciaProducto(string NoParte);

        Task<ExistenciaProducto> GetExistenciaProductoPorId(int id);

        Task<IEnumerable<ExistenciaProducto>> GetExistenciasProducto();

        Task<IEnumerable<OrdenCompra>> GetOrdenesCompraAbiertasXNumeroParte(string noParte);

        Task<Comprador> GetComprador(int id);

        Task<IEnumerable<Comprador>> GetCompradores();

        Task<OrdenCompraProveedor> GetOrdenCompraProveedor(string noOrden);

        Task<IEnumerable<OrdenCompraProveedor>> GetOrdenesCompraProveedores();

        Task<bool> ExisteFolioEmbarque(int Folio);

        Task<IEnumerable<Localidad>> GetLocalidades();

        Task<Localidad> GetLocalidad(int id);

        Task<bool> ExisteLocalidad(string localidad);

        Task<User> GetUser(string id);

        Task<bool> ExisteMoldeadora(string clave);

        Task<DetalleEmbarque> GetDetalleEmbarque(int id);

        Task<IEnumerable<DetalleEmbarque>> GetDetalleEmbarques(ReporteParams reporteParams);

        Task<IEnumerable<LocalidadNumeroParte>> GetLocalidadesNumeroParte(string NoParte);

        Task<LocalidadNumeroParte> GetLocalidadNumeroParte(int localidadId, string NoParte);

        Task<bool> ExisteOrdenCompra(long noOrden);

        Task<LocalidadMaterial> GetLocalidadMaterial(int localidadId, int MaterialId);

        Task<bool> ExisteMolde(string molde);

        Task<IEnumerable<EstatusMolde>> GetEstatusMoldes();

        Task<EstatusMolde> GetEstatusMolde(int id);

        Task<IEnumerable<Produccion>> GetProducciones(ProduccionParams produccionParams);

        Task<PlaneacionProduccion> GetPlaneacionProduccion(int año, int semana, string noParte);

        Task<IEnumerable<PlaneacionProduccion>> GetPlaneacionesProduccion(PlaneacionProduccionParams ppParams);

        Task<ExistenciaProductoProduccion> GetExistenciaProductoProduccionXNumeroParte(string noParte);

        Task<ExistenciaProductoProduccion> GetExistenciaProductoProduccion(int id);

        Task<IEnumerable<ExistenciaProductoProduccion>> GetExistenciasProductoProduccion();

        Task<IEnumerable<DetalleRecibo>> GetDetalleRecibos(ReporteParams reporteParams);

        Task<IEnumerable<MovimientoMaterial>> GetMovimientosMaterial(MovimientoMaterialParams movimientoParams);



    }
}