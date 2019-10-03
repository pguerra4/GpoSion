using System.Collections.Generic;
using System.Threading.Tasks;
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

        Task<IEnumerable<Material>> GetMateriales();
        Task<Material> GetMaterial(int id);
        Task<Material> GetMaterialByClienteNombre(int clienteId, string nombre);


        Task<IEnumerable<Recibo>> GetRecibos();
        Task<Recibo> GetRecibo(int id);



    }
}