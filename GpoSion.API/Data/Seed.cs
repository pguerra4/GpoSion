using System;
using System.Linq;
using GpoSion.API.Models;

namespace GpoSion.API.Data
{
    public class Seed
    {
        public static void SeedClientes(DataContext context)
        {
            if (!context.Clientes.Any())
            {
                var cliente = new Cliente { Clave = "NOVA", Nombre = "NOVARES", FechaCreacion = DateTime.Now };
                context.Clientes.Add(cliente);
                cliente = new Cliente { Clave = "FAWN", Nombre = "FAWN", FechaCreacion = DateTime.Now };
                context.Clientes.Add(cliente);
                cliente = new Cliente { Clave = "CARL", Nombre = "CARLISLE", FechaCreacion = DateTime.Now };
                context.Clientes.Add(cliente);

                context.SaveChanges();
            }
            if (!context.Proveedores.Any())
            {
                var proveedor = new Proveedor { Nombre = "NOVARES" };
                context.Proveedores.Add(proveedor);
                proveedor = new Proveedor { Nombre = "FAWN" };
                context.Proveedores.Add(proveedor);
                proveedor = new Proveedor { Nombre = "CARLISLE" };
                context.Proveedores.Add(proveedor);

                context.SaveChanges();
            }

            if (!context.UnidadesMedida.Any())
            {
                var unidadMedida = new UnidadMedida { Unidad = "LB", Descripcion = "Libra" };
                context.UnidadesMedida.Add(unidadMedida);
                unidadMedida = new UnidadMedida { Unidad = "KG", Descripcion = "Kilogramo" };
                context.UnidadesMedida.Add(unidadMedida);
                unidadMedida = new UnidadMedida { Unidad = "PZA", Descripcion = "Pieza" };
                context.UnidadesMedida.Add(unidadMedida);

                context.SaveChanges();
            }

            if (!context.Areas.Any())
            {
                var area = new Area { NombreArea = "Almacen", Abreviatura = "ALM" };
                context.Areas.Add(area);
                area = new Area { NombreArea = "Producción", Abreviatura = "PROD" };
                context.Areas.Add(area);

                context.SaveChanges();
            }


            if (!context.Turnos.Any())
            {
                var turno = new Turno { NoTurno = 1, Descripcion = "Matutino" };
                context.Turnos.Add(turno);
                turno = new Turno { NoTurno = 2, Descripcion = "Vespertino" };
                context.Turnos.Add(turno);
                turno = new Turno { NoTurno = 3, Descripcion = "Nocturno" };
                context.Turnos.Add(turno);

                context.SaveChanges();
            }
            if (!context.Moldeadoras.Any())
            {
                var moldeadora = new Moldeadora { Clave = "Moldeadora 1", Estatus = "Detenida" };
                context.Moldeadoras.Add(moldeadora);
                moldeadora = new Moldeadora { Clave = "Moldeadora 2", Estatus = "Detenida" };
                context.Moldeadoras.Add(moldeadora);
                moldeadora = new Moldeadora { Clave = "Moldeadora 3", Estatus = "Detenida" };
                context.Moldeadoras.Add(moldeadora);

                context.SaveChanges();
            }

            if (!context.MotivosTiempoMuerto.Any())
            {
                var motivo = new MotivoTiempoMuerto { Motivo = "Fin de turno" };
                context.MotivosTiempoMuerto.Add(motivo);
                motivo = new MotivoTiempoMuerto { Motivo = "Falla moldeadora" };
                context.MotivosTiempoMuerto.Add(motivo);
                context.SaveChanges();
            }

        }

    }
}