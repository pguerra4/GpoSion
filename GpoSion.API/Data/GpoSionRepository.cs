using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GpoSion.API.Helpers;
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
            .Include(e => e.Material).Include(e => e.Area)
           .OrderBy(e => e.Material.ClaveMaterial).ThenBy(e => e.UltimaModificacion).ToListAsync();
            return existencias;

        }

        public async Task<ExistenciaMaterial> GetExistencia(int id)
        {

            var existencia = await _context.ExistenciasMaterial.FindAsync(id);
            return existencia;
        }

        public async Task<IEnumerable<Material>> GetMateriales(MaterialParams materialParams)
        {

            var materiales = await _context.Materiales.Include(m => m.UnidadMedida).Include(m => m.TipoMaterial).ToListAsync();
            if (materialParams.Tipo.HasValue)
            {
                materiales = materiales.Where(m => m.TipoMaterialId == materialParams.Tipo.Value).ToList();
            }
            return materiales;
        }

        public async Task<Material> GetMaterial(int id)
        {

            var material = await _context.Materiales.Include(m => m.UnidadMedida).Include(m => m.TipoMaterial).FirstOrDefaultAsync(m => m.MaterialId == id);
            return material;
        }

        public async Task<IEnumerable<Recibo>> GetRecibos()
        {

            var recibos = await _context.Recibos.Include(r => r.Proveedor).Include(r => r.Detalle).OrderByDescending(r => r.FechaEntrada).ToListAsync();

            return recibos;

        }

        public async Task<Recibo> GetRecibo(int id)
        {

            var recibo = await _context.Recibos.Include(r => r.Detalle).ThenInclude(d => d.Material)
            .Include(r => r.Detalle).ThenInclude(d => d.UnidadMedida)
            .Include(r => r.Detalle).ThenInclude(d => d.Viajero).ThenInclude(v => v.Localizacion)
            .Include(r => r.Detalle).ThenInclude(d => d.Localidad)
            .Include(r => r.Proveedor).FirstOrDefaultAsync(r => r.ReciboId == id);
            return recibo;
        }

        public async Task<Material> GetMaterialByClienteNombre(int clienteId, string nombre)
        {

            var material = await _context.Materiales.Where(m => m.ClaveMaterial.ToLower() == nombre.ToLower()).FirstOrDefaultAsync();
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
            .Select(mm => mm.Viajero).Include(v => v.MovimientosMaterial).Include(v => v.Material).Include(v => v.Localizacion).OrderBy(v => v.Fecha).Distinct().ToListAsync();
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

        public async Task<IEnumerable<MovimientoMaterial>> GetMovimientoMaterialesPorViajero(int viajero)
        {
            var movs = await _context.MovimientosMaterial.Include(mm => mm.Origen).Include(mm => mm.Destino).Include(mm => mm.Recibo).Where(mm => mm.ViajeroId == viajero).ToListAsync();
            return movs;

        }

        public async Task<Viajero> GetViajero(int viajeroId)
        {

            var viajero = await _context.Viajeros.Include(v => v.Localizacion)
            .Include(v => v.MovimientosMaterial).ThenInclude(mm => mm.Origen)
            .Include(v => v.MovimientosMaterial).ThenInclude(mm => mm.Destino)
            .Include(v => v.MovimientosMaterial).ThenInclude(mm => mm.Material)
            .Include(v => v.MovimientosMaterial).ThenInclude(mm => mm.ModificadoPor)
            .Include(v => v.MovimientosMaterial).ThenInclude(mm => mm.CreadoPor)
            .Include(v => v.Material).FirstOrDefaultAsync(v => v.ViajeroId == viajeroId);
            return viajero;
        }

        public async Task<IEnumerable<Turno>> GetTurnos()
        {
            var turnos = await _context.Turnos.ToListAsync();
            return turnos;
        }

        public async Task<IEnumerable<ExistenciaMaterial>> GetExistenciasEnAlmacen()
        {
            var existenciasAlmacen = await _context.ExistenciasMaterial.Include(e => e.Material).ThenInclude(m => m.UnidadMedida)
            .Include(e => e.Material).Include(e => e.Area)
            .Include(e => e.Material).ThenInclude(m => m.MaterialNumerosParte)
            .Where(em => em.Area.NombreArea.ToLower() == "almacen" && em.Existencia > 0
            && em.Material.MaterialNumerosParte.Any(mnp => mnp.NumeroParte.OrdenesCompraDetalle.Any(ocd => (ocd.PiezasAutorizadas > ocd.PiezasSurtidas || ocd.PiezasAutorizadas == 0) && (ocd.FechaFin == null || ocd.FechaFin.Value > DateTime.Now.Date)))).ToListAsync();
            return existenciasAlmacen;
        }

        public async Task<IEnumerable<RequerimientoMaterial>> GetRequerimientosMaterial()
        {
            var requerimientos = await _context.RequerimientosMaterial.Include(r => r.Turno)
            .Include(r => r.Materiales).ThenInclude(m => m.Material)
            .Include(r => r.Materiales).ThenInclude(m => m.UnidadMedida)
            .Include(r => r.Materiales).ThenInclude(m => m.Viajero)
            .Where(r => r.Estatus != "Surtido")
            .ToListAsync();
            return requerimientos;
        }

        public async Task<RequerimientoMaterial> GetRequerimientoMaterial(int id)
        {
            var requerimiento = await _context.RequerimientosMaterial.Include(r => r.Turno)
            .Include(r => r.Materiales).ThenInclude(m => m.Material)
            .Include(r => r.Materiales).ThenInclude(m => m.UnidadMedida)
            .Include(r => r.Materiales).ThenInclude(m => m.Viajero).FirstOrDefaultAsync(r => r.RequerimientoMaterialId == id);
            return requerimiento;
        }

        public async Task<bool> ExisteRecibo(int noRecibo)
        {
            var recibo = await _context.Recibos.Where(r => r.NoRecibo == noRecibo).FirstOrDefaultAsync();

            return recibo != null;
        }

        public async Task<DetalleRecibo> GetDetalleRecibo(int Id)
        {
            var detalleRecibo = await _context.DetalleRecibos.Include(dr => dr.Viajero)
            .Include(dr => dr.Recibo).Include(dr => dr.Material).Include(dr => dr.UnidadMedida).FirstOrDefaultAsync(dr => dr.DetalleReciboId == Id);
            return detalleRecibo;
        }

        public async Task<IEnumerable<Viajero>> GetViajeros()
        {
            var viajeros = await _context.Viajeros.Include(v => v.Material)
            .Include(v => v.Localizacion)
            .Where(v => v.Existencia > 0).OrderBy(v => v.Fecha).ToListAsync();
            return viajeros;
        }

        public async Task<IEnumerable<Molde>> GetMoldes()
        {
            var moldes = await _context.Moldes.Include(m => m.Cliente).Include(m => m.Ubicacion).ToListAsync();
            return moldes;
        }

        public async Task<Molde> GetMolde(int Id)
        {
            var molde = await _context.Moldes.Include(m => m.Cliente).Include(m => m.Ubicacion)
            .Include(m => m.MoldeNumerosParte).FirstOrDefaultAsync(m => m.Id == Id);
            return molde;
        }

        public async Task<OrdenCompra> GetOrdenCompra(long Id)
        {
            var ordenCompra = await _context.OrdenesCompra.Include(oc => oc.Cliente).Include(oc => oc.NumerosParte).ThenInclude(np => np.NumeroParte).FirstOrDefaultAsync(oc => oc.NoOrden == Id);
            return ordenCompra;
        }

        public async Task<IEnumerable<OrdenCompra>> GetOrdenesCompra()
        {
            var ordenesCompra = await _context.OrdenesCompra.Include(oc => oc.Cliente).Include(oc => oc.NumerosParte).ThenInclude(np => np.NumeroParte).ToListAsync();
            return ordenesCompra;
        }

        public async Task<NumeroParte> GetNumeroParte(string NoParte)
        {
            var numeroParte = await _context.NumerosParte.Include(np => np.Cliente)
            .Include(np => np.MaterialesNumeroParte).ThenInclude(mnp => mnp.Material).ThenInclude(m => m.UnidadMedida)
            .Include(np => np.MaterialesNumeroParte).ThenInclude(mnp => mnp.Material).ThenInclude(m => m.TipoMaterial)
            .Include(np => np.MoldesNumeroParte).ThenInclude(mnp => mnp.Molde)
            .Include(np => np.MoldeadorasNumeroParte).ThenInclude(mnp => mnp.Moldeadora)
            .Include(np => np.ExistenciasProducto).FirstOrDefaultAsync(np => np.NoParte == NoParte);
            return numeroParte;
        }

        public async Task<IEnumerable<NumeroParte>> GetNumerosParte(NumeroParteParams numeroParteParams)
        {
            var numerosParte = await _context.NumerosParte.Include(np => np.Cliente)
            .Include(np => np.MaterialesNumeroParte).ThenInclude(mnp => mnp.Material)
            .Include(np => np.MoldesNumeroParte).ThenInclude(mnp => mnp.Molde)
            .Include(np => np.MoldeadorasNumeroParte).ThenInclude(mnp => mnp.Moldeadora).ToListAsync();
            if (numeroParteParams.ClienteId.HasValue)
            {
                numerosParte = numerosParte.Where(np => np.ClienteId == numeroParteParams.ClienteId.Value).ToList();
            }
            return numerosParte;
        }

        public async Task<Moldeadora> GetMoldeadora(int Id)
        {
            var moldeadora = await _context.Moldeadoras.Include(m => m.MoldeadoraNumerosParte)
            .Include(m => m.Molde).Include(m => m.Material).FirstOrDefaultAsync(m => m.MoldeadoraId == Id);
            return moldeadora;
        }

        public async Task<IEnumerable<Moldeadora>> GetMoldeadoras()
        {
            var moldeadoras = await _context.Moldeadoras.Include(m => m.MoldeadoraNumerosParte)
            .Include(m => m.Molde).Include(m => m.Material).ToListAsync();
            return moldeadoras;
        }

        public async Task<TipoMaterial> GetTipoMaterial(int id)
        {
            var tipoMaterial = await _context.TiposMaterial.FindAsync(id);
            return tipoMaterial;
        }

        public async Task<IEnumerable<TipoMaterial>> GetTiposMaterial()
        {
            var tiposMaterial = await _context.TiposMaterial.ToListAsync();
            return tiposMaterial;
        }

        public async Task<bool> ExisteTipoMaterial(string tipo)
        {
            var tipoMaterial = await _context.TiposMaterial.Where(tp => tp.Tipo == tipo).FirstOrDefaultAsync();

            return tipoMaterial != null;
        }

        public async Task<bool> ExisteMaterial(string material, int id)
        {
            var materialFromRepo = await _context.Materiales.Where(m => m.ClaveMaterial == material && m.MaterialId != id).FirstOrDefaultAsync();

            return materialFromRepo != null;
        }

        public async Task<bool> ExisteNumeroParte(string NoParte)
        {
            var numeroParte = await _context.NumerosParte.FindAsync(NoParte);
            return numeroParte != null;
        }

        public async Task<IEnumerable<Proveedor>> GetProveedores()
        {
            var proveedores = await _context.Proveedores.ToListAsync();
            return proveedores;
        }

        public async Task<OrdenCompraDetalle> GetOrdenCompraDetalle(int id)
        {
            var ordenCompraDetalle = await _context.OrdenCompraDetalles.Include(ocd => ocd.NumeroParte).FirstOrDefaultAsync(ocd => ocd.Id == id);
            return ordenCompraDetalle;
        }

        public async Task<bool> ExisteOrdenCompraActiva(string noParte)
        {
            var existe = await _context.OrdenCompraDetalles.AnyAsync(ocd => ocd.NoParte == noParte && (ocd.PiezasAutorizadas > ocd.PiezasSurtidas || ocd.PiezasAutorizadas == 0) && (ocd.FechaFin == null || ocd.FechaFin.Value > DateTime.Now.Date));
            return existe;
        }

        public async Task<IEnumerable<MotivoTiempoMuerto>> GetMotivosTiempoMuerto()
        {
            var motivos = await _context.MotivosTiempoMuerto.ToListAsync();
            return motivos;
        }

        public async Task<MotivoTiempoMuerto> GetMotivoTiempoMuerto(int id)
        {
            var motivo = await _context.MotivosTiempoMuerto.FindAsync(id);
            return motivo;
        }

        public async Task<Proveedor> GetProveedor(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            return proveedor;
        }

        public async Task<MovimientoProducto> GetMovimientoProducto(int id)
        {
            var movimiento = await _context.MovimientosProducto.FindAsync(id);
            return movimiento;
        }

        public async Task<IEnumerable<MovimientoProducto>> GetMovimientosProducto(MovimientoProductoParams movimientoParams)
        {

            var movimientos = await _context.MovimientosProducto.OrderByDescending(mp => mp.UltimaModificacion).ToListAsync();
            if (movimientoParams.Fecha.HasValue)
            {
                movimientos = movimientos.Where(m => m.Fecha.Date == movimientoParams.Fecha.Value.Date).ToList();
            }
            if (movimientoParams.TipoMovimiento != "")
            {
                movimientos = movimientos.Where(m => m.TipoMovimiento == movimientoParams.TipoMovimiento).ToList();
            }
            return movimientos;
        }

        public async Task<ExistenciaProducto> GetExistenciaProducto(string NoParte)
        {
            var existencia = await _context.ExistenciasProducto.FirstOrDefaultAsync(e => e.NoParte == NoParte);
            return existencia;
        }

        public async Task<IEnumerable<ExistenciaProducto>> GetExistenciasProducto()
        {
            var existencias = await _context.ExistenciasProducto.ToListAsync();
            return existencias;
        }

        public async Task<Embarque> GetEmbarque(int id)
        {
            var embarque = await _context.Embarques.Include(e => e.Cliente).Include(e => e.DetallesEmbarque).ThenInclude(de => de.OrdenCompra).FirstOrDefaultAsync(e => e.EmbarqueId == id);
            return embarque;
        }

        public async Task<IEnumerable<Embarque>> GetEmbarques(EmbarqueParams embarqueParams)
        {
            var embarques = await _context.Embarques.Include(e => e.Cliente).Include(e => e.DetallesEmbarque).ThenInclude(de => de.OrdenCompra).ToListAsync();
            if (embarqueParams.ClienteId.HasValue)
            {
                embarques = embarques.Where(e => e.ClienteId == embarqueParams.ClienteId).ToList();
            }
            if (embarqueParams.Fecha.HasValue)
            {
                embarques = embarques.Where(e => e.Fecha.Date == embarqueParams.Fecha.Value.Date).ToList();
            }
            return embarques;

        }

        public async Task<IEnumerable<OrdenCompra>> GetOrdenesCompraAbiertasXNumeroParte(string noParte)
        {
            var ordenesCompra = await _context.OrdenesCompra.Include(oc => oc.Cliente)
            .Include(oc => oc.NumerosParte).ThenInclude(np => np.NumeroParte)
            .Where(oc => oc.NumerosParte.Any(np => np.NoParte == noParte && ((np.PiezasAutorizadas == 0 || np.PiezasAutorizadas > np.PiezasSurtidas) && ((np.FechaFin.HasValue && np.FechaFin.Value.Date >= DateTime.Now.Date) || !np.FechaFin.HasValue)))).ToListAsync();
            return ordenesCompra;
        }

        public async Task<Comprador> GetComprador(int id)
        {
            var comprador = await _context.Compradores.FindAsync(id);
            return comprador;
        }

        public async Task<IEnumerable<Comprador>> GetCompradores()
        {
            var compradores = await _context.Compradores.ToListAsync();
            return compradores;
        }

        public async Task<OrdenCompraProveedor> GetOrdenCompraProveedor(string noOrden)
        {
            var orden = await _context.OrdenesCompraProveedores.Include(ocp => ocp.Comprador).Include(ocp => ocp.Proveedor)
            .Include(ocp => ocp.Materiales).ThenInclude(m => m.Material).FirstOrDefaultAsync(ocp => ocp.NoOrden == noOrden);
            return orden;
        }

        public async Task<IEnumerable<OrdenCompraProveedor>> GetOrdenesCompraProveedores()
        {
            var ordenes = await _context.OrdenesCompraProveedores.Include(ocp => ocp.Comprador).Include(ocp => ocp.Proveedor)
            .Include(ocp => ocp.Materiales).ThenInclude(m => m.Material).ToListAsync();
            return ordenes;
        }

        public async Task<bool> ExisteFolioEmbarque(int Folio)
        {
            var embarque = await _context.Embarques.FirstOrDefaultAsync(e => e.Folio == Folio);
            return embarque != null;
        }

        public async Task<IEnumerable<Localidad>> GetLocalidades()
        {
            var localidades = await _context.Localidades.ToListAsync();
            return localidades;

        }

        public async Task<Localidad> GetLocalidad(int id)
        {
            var localidad = await _context.Localidades.FindAsync(id);
            return localidad;
        }

        public async Task<bool> ExisteLocalidad(string localidad)
        {
            var local = await _context.Localidades.FirstOrDefaultAsync(e => e.Descripcion == localidad);
            return local != null;
        }

        public async Task<User> GetUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }
    }
}