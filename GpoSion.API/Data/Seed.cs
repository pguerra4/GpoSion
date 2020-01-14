using System;
using System.Linq;
using GpoSion.API.Models;

namespace GpoSion.API.Data
{
    public class Seed
    {
        public static void SeedClientes(DataContext context)
        {
            if (!context.Compradores.Any())
            {
                var comprador = new Comprador { Nombre = "Manyser LLC", Direccion = "5959 Gateway West, Suite 401\nEl Paso, TX 79925\n210-241-1163" };
                context.Compradores.Add(comprador);
                comprador = new Comprador { Nombre = "Manyser Manufacturas y Servicios, S.A. de C.V.", Direccion = "Circuito Gabriel Garcia Marquez no. 170\nComplejo Industrial Chihuahua\nCP 31136 Chihuahua, Chih México\nTel (614) 481-4666\nFax (614) 481-0182", RFC = "MMS-960704-D98" };
                context.Compradores.Add(comprador);

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

            if (!context.Localidades.Any())
            {
                var localidades = context.Viajeros.Select(v => v.Localidad).Distinct();
                foreach (var item in localidades)
                {
                    context.Localidades.Add(new Localidad { Descripcion = item });
                }
                context.SaveChanges();
                var viajeros = context.Viajeros.Where(v => v.LocalidadId == null && v.Localidad != null);
                foreach (var item in viajeros)
                {
                    var localidad = context.Localidades.FirstOrDefault(l => l.Descripcion == item.Localidad);
                    if (localidad != null)
                    {
                        item.LocalidadId = localidad.LocalidadId;
                    }
                }
                context.SaveChanges();
            }


            if (!context.Turnos.Any())
            {
                var turno = new Turno { NoTurno = 1, Descripcion = "Matutino" };
                context.Turnos.Add(turno);
                turno = new Turno { NoTurno = 2, Descripcion = "Vespertino" };

                context.Turnos.Add(turno);

                context.SaveChanges();
            }


            if (!context.MotivosTiempoMuerto.Any())
            {
                var motivo = new MotivoTiempoMuerto { Motivo = "Fin de turno" };
                context.MotivosTiempoMuerto.Add(motivo);

                context.SaveChanges();
            }
            if (!context.TiposMaterial.Any())
            {
                var tipo = new TipoMaterial { Tipo = "Resina" };
                context.TiposMaterial.Add(tipo);

                context.SaveChanges();
            }

        }

    }
}