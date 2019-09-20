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

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}