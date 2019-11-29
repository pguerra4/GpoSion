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

        Task<IEnumerable<MovimientoMaterial>> GetMovimientoMateriales();
        Task<MovimientoMaterial> GetMovimientoMaterial(int id);

        Task<IEnumerable<MovimientoMaterial>> GetMovimientoMaterialesPorViajero(int viajero);

        Task<Viajero> GetViajero(int viajeroId);

        Task<IEnumerable<Turno>> GetTurnos();

        Task<IEnumerable<ExistenciaMaterial>> GetExistenciasEnAlmacen();

        Task<IEnumerable<RequerimientoMaterial>> GetRequerimientosMaterial();

        Task<RequerimientoMaterial> GetRequerimientoMaterial(int id);

        Task<bool> ExisteRecibo(int noRecibo);

        Task<DetalleRecibo> GetDetalleRecibo(int Id);

        Task<IEnumerable<Viajero>> GetViajeros();

        Task<IEnumerable<Molde>> GetMoldes();

        Task<Molde> GetMolde(int Id);

        Task<OrdenCompra> GetOrdenCompra(int Id);

        Task<IEnumerable<OrdenCompra>> GetOrdenesCompra();

        Task<NumeroParte> GetNumeroParte(string NoParte);

        Task<IEnumerable<NumeroParte>> GetNumerosParte();

        Task<Moldeadora> GetMoldeadora(int Id);

        Task<IEnumerable<Moldeadora>> GetMoldeadoras();

        Task<TipoMaterial> GetTipoMaterial(int id);

        Task<IEnumerable<TipoMaterial>> GetTiposMaterial();

        Task<bool> ExisteTipoMaterial(string tipo);

        Task<bool> ExisteMaterial(string material, int id);

        Task<bool> ExisteNumeroParte(string NoParte);

        Task<IEnumerable<Proveedor>> GetProveedores();

        Task<OrdenCompraDetalle> GetOrdenCompraDetalle(int id);

        Task<bool> ExisteOrdenCompraActiva(string noParte);

        Task<IEnumerable<MotivoTiempoMuerto>> GetMotivosTiempoMuerto();
        Task<MotivoTiempoMuerto> GetMotivoTiempoMuerto(int id);

    }
}