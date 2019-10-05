using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GpoSion.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GpoSion.API.Data
{
    public class GpoSionRepository : IGpoSionRepository
    {
        private readonly DataContext _context;
        public GpoSionRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Cliente> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return clientes;
        }

        public async Task<IEnumerable<UnidadMedida>> GetUnidadesMedida()
        {
            var unidadesMedida = await _context.UnidadesMedida.ToListAsync();
            return unidadesMedida;
        }

        public async Task<UnidadMedida> GetUnidadMedida(int id)
        {
            var unidadMedida = await _context.UnidadesMedida.FindAsync(id);

            return unidadMedida;
        }

        public async Task<IEnumerable<Area>> GetAreas()
        {
            var areas = await _context.Areas.ToListAsync();
            return areas;
        }

        public async Task<Area> GetArea(int id)
        {
            var area = await _context.Areas.FindAsync(id);

            return area;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ExistenciaMaterial>> GetExistencias()
        {

            var existencias = await _context.ExistenciasMaterial.Include(e => e.Material).ThenInclude(m => m.UnidadMedida)
            .Include(e => e.Material).ThenInclude(m => m.Cliente).Include(e => e.Area).OrderBy(e => e.Material.ClaveMaterial).ThenBy(e => e.UltimaModificacion).ToListAsync();
            return existencias;
        }

        public async Task<ExistenciaMaterial> GetExistencia(int id)
        {

            var existencia = await _context.ExistenciasMaterial.FindAsync(id);
            return existencia;
        }

        public async Task<IEnumerable<Material>> GetMateriales()
        {

            var materiales = await _context.Materiales.Include(m => m.Cliente).Include(m => m.UnidadMedida).ToListAsync();
            return materiales;
        }

        public async Task<Material> GetMaterial(int id)
        {

            var material = await _context.Materiales.Include(m => m.Cliente).Include(m => m.UnidadMedida).FirstOrDefaultAsync(m => m.MaterialId == id);
            return material;
        }

        public async Task<IEnumerable<Recibo>> GetRecibos()
        {

            var recibos = await _context.Recibos.Include(r => r.Cliente).Include(r => r.Detalle).OrderByDescending(r => r.FechaEntrada).ToListAsync();

            return recibos;

        }

        public async Task<Recibo> GetRecibo(int id)
        {

            var recibo = await _context.Recibos.Include(r => r.Detalle).ThenInclude(d => d.Material)
            .Include(r => r.Detalle).ThenInclude(d => d.UnidadMedida)
            .Include(r => r.Cliente).FirstOrDefaultAsync(r => r.ReciboId == id);
            return recibo;
        }

        public async Task<Material> GetMaterialByClienteNombre(int clienteId, string nombre)
        {

            var material = await _context.Materiales.Where(m => m.Cliente.ClienteId == clienteId && m.ClaveMaterial.ToLower() == nombre.ToLower()).FirstOrDefaultAsync();
            return material;
        }

        public async Task<ExistenciaMaterial> GetExistenciaPorAreaMaterial(int areaId, int materialId)
        {

            var existenciaMaterial = await _context.ExistenciasMaterial.FirstOrDefaultAsync(em => em.Area.AreaId == areaId && em.Material.MaterialId == materialId);
            return existenciaMaterial;
        }

        public async Task<IEnumerable<Viajero>> GetViajerosPorMaterial(int materialId)
        {
            var viajeros = await _context.MovimientosMaterial.Where(mm => mm.Material.MaterialId == materialId && mm.ViajeroId != null)
            .Select(mm => mm.Viajero).Include(v => v.MovimientosMaterial).Include(v => v.Material).OrderBy(v => v.Fecha).ToListAsync();
            return viajeros;
        }

        public Task<IEnumerable<MovimientoMaterial>> GetMovimientoMateriales()
        {
            throw new System.NotImplementedException();
        }

        public Task<MovimientoMaterial> GetMovimientoMaterial(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<MovimientoMaterial>> GetMovimientoMaterialesPorViajero(int viajero)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Viajero> GetViajero(int viajeroId)
        {

            var viajero = await _context.Viajeros.Include(v => v.MovimientosMaterial).ThenInclude(mm => mm.Origen)
            .Include(v => v.MovimientosMaterial).ThenInclude(mm => mm.Destino)
            .Include(v => v.MovimientosMaterial).ThenInclude(mm => mm.Material)
            .Include(v => v.Material).FirstOrDefaultAsync(v => v.ViajeroId == viajeroId);
            return viajero;
        }
    }
}