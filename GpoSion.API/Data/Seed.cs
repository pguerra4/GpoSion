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
        }

    }
}