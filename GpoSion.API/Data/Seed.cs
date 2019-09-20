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
        }

    }
}