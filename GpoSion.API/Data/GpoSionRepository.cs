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

            var existencias = await _context.ExistenciasMaterial
           .OrderBy(e => e.Material.ClaveMaterial).ThenBy(e => e.UltimaModificacion.HasValue ? e.UltimaModificacion.Value : e.FechaCreacion.Value).ToListAsync();
            return existencias;

        }

        public async Task<ExistenciaMaterial> GetExistencia(int id)
        {

            var existencia = await _context.ExistenciasMaterial.FindAsync(id);
            return existencia;
        }

        public async Task<IEnumerable<Material>> GetMateriales(MaterialParams materialParams)
        {

            var materiales = await _context.Materiales.ToListAsync();
            if (materialParams.Tipo.HasValue)
            {
                materiales = materiales.Where(m => m.TipoMaterialId == materialParams.Tipo.Value).ToList();
            }
            return materiales;
        }

        public async Task<Material> GetMaterial(int id)
        {

            var material = await _context.Materiales.FirstOrDefaultAsync(m => m.MaterialId == id);
            return material;
        }

        public async Task<IEnumerable<Recibo>> GetRecibos()
        {

            var recibos = await _context.Recibos.OrderByDescending(r => r.FechaEntrada).ToListAsync();

            return recibos;

        }

        public async Task<Recibo> GetRecibo(int id)
        {

            var recibo = await _context.Recibos.FirstOrDefaultAsync(r => r.ReciboId == id);
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
            var viajeros = await _context.MovimientosMaterial.Where(mm => mm.Material.MaterialId == materialId && mm.ViajeroId != null && mm.Viajero.Existencia > 0)
            .Select(mm => mm.Viajero).Distinct().ToListAsync();

            var FechaMasLejana = viajeros.Min(v => v.Fecha).AddMinutes(-1);


            var localidadesConMaterial = await _context.LocalidadesMateriales.Where(lm => lm.MaterialId == materialId && lm.Existencia > 0
            && !viajeros.Any(v => v.LocalidadId == lm.LocalidadId)).ToListAsync();
            foreach (var lm in localidadesConMaterial)
            {
                viajeros.Add(new Viajero { ViajeroId = 0, LocalidadId = lm.LocalidadId, Localizacion = lm.Localidad, Existencia = lm.Existencia, MaterialId = lm.MaterialId, Fecha = FechaMasLejana, Material = lm.Material });
            }
            viajeros = viajeros.OrderBy(v => v.Fecha).ToList();


            return viajeros;
        }

        public async Task<IEnumerable<MovimientoMaterial>> GetMovimientoMateriales(RetornoMaterialParams retornoParams)
        {
            var movimientosMateriales = await _context.MovimientosMaterial.Where(mm => mm.Origen.AreaId == 2 && mm.Destino.AreaId == 1 && mm.Viajero == null && mm.MotivoMovimiento == "Retorno Material").ToListAsync();
            if (retornoParams.FechaInicio.HasValue)
            {
                movimientosMateriales = movimientosMateriales.Where(mm => mm.Fecha >= retornoParams.FechaInicio).ToList();
            }
            if (retornoParams.FechaFin.HasValue)
            {
                movimientosMateriales = movimientosMateriales.Where(mm => mm.Fecha <= retornoParams.FechaFin).ToList();
            }
            return movimientosMateriales;
        }

        public async Task<MovimientoMaterial> GetMovimientoMaterial(int id)
        {
            var movimientoMaterial = await _context.MovimientosMaterial.FindAsync(id);
            return movimientoMaterial;
        }

        public async Task<IEnumerable<MovimientoMaterial>> GetMovimientoMaterialesPorViajero(int viajero)
        {
            var movs = await _context.MovimientosMaterial.Where(mm => mm.ViajeroId == viajero).ToListAsync();
            return movs;

        }

        public async Task<Viajero> GetViajero(int viajeroId)
        {

            var viajero = await _context.Viajeros.FirstOrDefaultAsync(v => v.ViajeroId == viajeroId);
            return viajero;
        }

        public async Task<IEnumerable<Turno>> GetTurnos()
        {
            var turnos = await _context.Turnos.ToListAsync();
            return turnos;
        }

        public async Task<IEnumerable<ExistenciaMaterial>> GetExistenciasEnAlmacen()
        {
            var existenciasAlmacen = await _context.ExistenciasMaterial
            .Where(em => em.Area.NombreArea.ToLower() == "almacen" && em.Existencia > 0
            && em.Material.MaterialNumerosParte.Any(mnp => mnp.NumeroParte.OrdenesCompraDetalle.Any(ocd => (ocd.PiezasAutorizadas > ocd.PiezasSurtidas || ocd.PiezasAutorizadas == 0) && (ocd.FechaFin == null || ocd.FechaFin.Value > DateTime.Now.Date)))).ToListAsync();
            return existenciasAlmacen;
        }

        public async Task<IEnumerable<RequerimientoMaterial>> GetRequerimientosMaterial(RequerimientoParams requerimientoParams)
        {
            var requerimientos = await _context.RequerimientosMaterial.ToListAsync();

            if (requerimientoParams.MostrarSurtidos.HasValue && !requerimientoParams.MostrarSurtidos.Value)
            {
                requerimientos = requerimientos.Where(r => r.Estatus != "Surtido").ToList();
            }
            if (requerimientoParams.FechaInicio.HasValue && requerimientoParams.FechaFin.HasValue)
            {
                requerimientos = requerimientos.Where(e => e.FechaSolicitud.Date >= requerimientoParams.FechaInicio.Value.Date && e.FechaSolicitud.Date <= requerimientoParams.FechaFin.Value.Date).ToList();
            }
            else if (requerimientoParams.FechaInicio.HasValue)
            {
                requerimientos = requerimientos.Where(e => e.FechaSolicitud.Date >= requerimientoParams.FechaInicio.Value.Date).ToList();
            }
            return requerimientos;
        }

        public async Task<RequerimientoMaterial> GetRequerimientoMaterial(int id)
        {
            var requerimiento = await _context.RequerimientosMaterial.FirstOrDefaultAsync(r => r.RequerimientoMaterialId == id);
            return requerimiento;
        }

        public async Task<bool> ExisteRecibo(int noRecibo)
        {
            var recibo = await _context.Recibos.Where(r => r.NoRecibo == noRecibo).FirstOrDefaultAsync();

            return recibo != null;
        }

        public async Task<DetalleRecibo> GetDetalleRecibo(int Id)
        {
            var detalleRecibo = await _context.DetalleRecibos.FirstOrDefaultAsync(dr => dr.DetalleReciboId == Id);
            return detalleRecibo;
        }

        public async Task<IEnumerable<Viajero>> GetViajeros()
        {
            var viajeros = await _context.Viajeros.OrderBy(v => v.Fecha).ToListAsync();
            return viajeros;
        }

        public async Task<IEnumerable<Molde>> GetMoldes()
        {
            var moldes = await _context.Moldes.ToListAsync();
            return moldes;
        }

        public async Task<Molde> GetMolde(int Id)
        {
            var molde = await _context.Moldes.FirstOrDefaultAsync(m => m.Id == Id);
            return molde;
        }

        public async Task<OrdenCompra> GetOrdenCompra(long Id)
        {
            var ordenCompra = await _context.OrdenesCompra.FirstOrDefaultAsync(oc => oc.NoOrden == Id);
            return ordenCompra;
        }

        public async Task<IEnumerable<OrdenCompra>> GetOrdenesCompra()
        {
            var ordenesCompra = await _context.OrdenesCompra.ToListAsync();
            return ordenesCompra;
        }

        public async Task<NumeroParte> GetNumeroParte(string NoParte)
        {
            var numeroParte = await _context.NumerosParte.FirstOrDefaultAsync(np => np.NoParte == NoParte);
            return numeroParte;
        }

        public async Task<IEnumerable<NumeroParte>> GetNumerosParte(NumeroParteParams numeroParteParams)
        {
            var numerosParte = await _context.NumerosParte.ToListAsync();
            if (numeroParteParams.ClienteId.HasValue)
            {
                numerosParte = numerosParte.Where(np => np.ClienteId == numeroParteParams.ClienteId.Value).ToList();
            }
            return numerosParte;
        }

        public async Task<Moldeadora> GetMoldeadora(int Id)
        {
            var moldeadora = await _context.Moldeadoras.FirstOrDefaultAsync(m => m.MoldeadoraId == Id);
            return moldeadora;
        }

        public async Task<IEnumerable<Moldeadora>> GetMoldeadoras()
        {
            var moldeadoras = await _context.Moldeadoras.ToListAsync();
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
            var ordenCompraDetalle = await _context.OrdenCompraDetalles.FirstOrDefaultAsync(ocd => ocd.Id == id);
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

            var movimientos = await _context.MovimientosProducto.OrderByDescending(mp => mp.Fecha).ToListAsync();
            if (movimientoParams.FechaInicio.HasValue)
            {
                movimientos = movimientos.Where(m => m.Fecha.Date >= movimientoParams.FechaInicio.Value.Date).ToList();
            }
            if (movimientoParams.FechaFin.HasValue)
            {
                movimientos = movimientos.Where(m => m.Fecha.Date <= movimientoParams.FechaFin.Value.Date).ToList();
            }
            if (movimientoParams.TipoMovimiento != null && movimientoParams.TipoMovimiento != "")
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
            var existencias = await _context.ExistenciasProducto.Where(e => e.PiezasCertificadas > 0 || e.PiezasRechazadas > 0).ToListAsync();
            return existencias;
        }


        public async Task<ExistenciaProducto> GetExistenciaProductoPorId(int id)
        {
            var existencia = await _context.ExistenciasProducto.FindAsync(id);
            return existencia;
        }

        public async Task<Embarque> GetEmbarque(int id)
        {
            var embarque = await _context.Embarques.FirstOrDefaultAsync(e => e.EmbarqueId == id);
            return embarque;
        }

        public async Task<IEnumerable<Embarque>> GetEmbarques(EmbarqueParams embarqueParams)
        {
            var embarques = await _context.Embarques.ToListAsync();
            if (embarqueParams.ClienteId.HasValue)
            {
                embarques = embarques.Where(e => e.ClienteId == embarqueParams.ClienteId).ToList();
            }
            if (embarqueParams.FechaInicio.HasValue && embarqueParams.FechaFin.HasValue)
            {
                embarques = embarques.Where(e => e.Fecha.Date >= embarqueParams.FechaInicio.Value.Date && e.Fecha.Date <= embarqueParams.FechaFin.Value.Date).ToList();
            }
            else if (embarqueParams.FechaInicio.HasValue)
            {
                embarques = embarques.Where(e => e.Fecha.Date >= embarqueParams.FechaInicio.Value.Date).ToList();
            }

            return embarques;

        }

        public async Task<IEnumerable<OrdenCompra>> GetOrdenesCompraAbiertasXNumeroParte(string noParte)
        {
            var ordenesCompra = await _context.OrdenesCompra
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
            var orden = await _context.OrdenesCompraProveedores.FirstOrDefaultAsync(ocp => ocp.NoOrden == noOrden);
            return orden;
        }

        public async Task<IEnumerable<OrdenCompraProveedor>> GetOrdenesCompraProveedores()
        {
            var ordenes = await _context.OrdenesCompraProveedores.ToListAsync();
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

        public async Task<bool> ExisteMoldeadora(string clave)
        {
            var moldeadora = await _context.Moldeadoras.FirstOrDefaultAsync(m => m.Clave.Trim().ToLower() == clave.Trim().ToLower());
            return moldeadora != null;
        }

        public async Task<DetalleEmbarque> GetDetalleEmbarque(int id)
        {
            var detalleEmbarque = await _context.DetallesEmbarque.FindAsync(id);
            return detalleEmbarque;
        }

        public async Task<IEnumerable<LocalidadNumeroParte>> GetLocalidadesNumeroParte(string NoParte)
        {
            var localidadesNumeroParte = await _context.LocalidadesNumerosParte.Where(lnp => lnp.NoParte == NoParte && lnp.Existencia > 0).OrderBy(lnp => lnp.UltimaModificacion.HasValue ? lnp.UltimaModificacion : lnp.FechaCreacion).ToListAsync();
            return localidadesNumeroParte;
        }

        public async Task<LocalidadNumeroParte> GetLocalidadNumeroParte(int localidadId, string NoParte)
        {
            var localidadNumeroParte = await _context.LocalidadesNumerosParte.FindAsync(localidadId, NoParte);
            return localidadNumeroParte;
        }

        public async Task<bool> ExisteOrdenCompra(long noOrden)
        {
            var ordenCompra = await _context.OrdenesCompra.FindAsync(noOrden);
            return ordenCompra != null;
        }

        public async Task<LocalidadMaterial> GetLocalidadMaterial(int localidadId, int MaterialId)
        {
            var localidadMaterial = await _context.LocalidadesMateriales.FindAsync(localidadId, MaterialId);
            return localidadMaterial;
        }

        public async Task<bool> ExisteMolde(string molde)
        {
            var moldeFromRepo = await _context.Moldes.FirstOrDefaultAsync(m => m.ClaveMolde == molde);
            return moldeFromRepo != null;
        }

        public async Task<IEnumerable<EstatusMolde>> GetEstatusMoldes()
        {
            var estatusMoldes = await _context.EstatusMolde.ToListAsync();
            return estatusMoldes;
        }

        public async Task<EstatusMolde> GetEstatusMolde(int id)
        {
            var estatusMolde = await _context.EstatusMolde.FindAsync(id);
            return estatusMolde;
        }

        public async Task<IEnumerable<Produccion>> GetProducciones(ProduccionParams produccionParams)
        {
            var producciones = await _context.Produccion.ToListAsync();

            if (produccionParams.FechaInicio.HasValue && produccionParams.FechaFin.HasValue)
            {
                producciones = producciones.Where(e => e.Fecha.Date >= produccionParams.FechaInicio.Value.Date && e.Fecha.Date <= produccionParams.FechaFin.Value.Date).ToList();
            }
            else if (produccionParams.FechaInicio.HasValue)
            {
                producciones = producciones.Where(e => e.Fecha.Date >= produccionParams.FechaInicio.Value.Date).ToList();
            }

            return producciones;

        }
    }
}