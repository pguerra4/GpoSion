using System.Collections.Generic;
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
            var existencias = await _context.ExistenciasMaterial.ToListAsync();
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
            var material = await _context.Materiales.FindAsync(id);
            return material;
        }
    }
}