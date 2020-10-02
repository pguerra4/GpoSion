using System;
using System.Collections.Generic;
using System.Linq;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Identity;

namespace GpoSion.API.Data
{
    public class Seed
    {
        public static void SeedUsers(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (!userManager.Users.Any())
            {
                if (!roleManager.Roles.Any())
                {
                    var roles = new List<Role>
                    {
                        new Role{Name = "Admin"},
                        new Role{Name = "Almacen"},
                        new Role{Name = "Produccion"},
                        new Role{Name = "Compras"},
                        new Role{Name = "Ventas"},
                        new Role{Name = "Calidad"},
                        new Role{Name = "Sistemas"}
                    };

                    foreach (var role in roles)
                    {
                        roleManager.CreateAsync(role).Wait();
                    }

                }


                var result = userManager.CreateAsync(new User { UserName = "Admin", Activo = true, Nombre = "Administrador", Paterno = "Sistema", FechaCreacion = DateTime.Now }, "M@nys3r2020").Result;
                if (result.Succeeded)
                {
                    var admin = userManager.FindByNameAsync("Admin").Result;
                    userManager.AddToRoleAsync(admin, "Admin").Wait();

                }
            }

            if (!roleManager.Roles.Any(r => r.Name == "AlmacenProducto"))
            {
                var roles = new List<Role>
                    {
                        new Role{Name = "AlmacenProducto"},
                        new Role{Name = "AlmacenMateriaPrima"}
                    };

                foreach (var role in roles)
                {
                    roleManager.CreateAsync(role).Wait();
                }

            }

        }
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
                        var detalleRecibo = context.DetalleRecibos.FirstOrDefault(dr => dr.ViajeroId == item.ViajeroId);
                        if (detalleRecibo != null)
                        {
                            detalleRecibo.LocalidadId = localidad.LocalidadId;
                        }
                    }
                }
                context.SaveChanges();
            }


            if (!context.Turnos.Any())
            {
                var turno = new Turno { NoTurno = 1, Descripcion = "1" };
                context.Turnos.Add(turno);
                turno = new Turno { NoTurno = 2, Descripcion = "2" };

                context.Turnos.Add(turno);
                turno = new Turno { NoTurno = 3, Descripcion = "3" };

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

            if (!context.EstatusMolde.Any())
            {
                var estatus = new EstatusMolde { Estatus = "Almacen", FechaCreacion = DateTime.Now };
                context.EstatusMolde.Add(estatus);
                estatus = new EstatusMolde { Estatus = "Producción", FechaCreacion = DateTime.Now };
                context.EstatusMolde.Add(estatus);

                context.SaveChanges();

                var moldes = context.Moldes.Where(m => m.EstatusMoldeId == null).ToList();
                foreach (var molde in moldes)
                {
                    if (molde.UbicacionAreaId == 1)
                    {
                        molde.EstatusMoldeId = 1;
                    }
                    else
                    {
                        molde.EstatusMoldeId = 2;
                    }
                }
                context.SaveChanges();
            }
            else
            {
                var molde = context.EstatusMolde.Where(m => m.Estatus == "Devolución a cliente").FirstOrDefault();
                if (molde == null)
                {
                    var estatus = new EstatusMolde { Estatus = "Devolución a cliente", FechaCreacion = DateTime.Now };
                    context.EstatusMolde.Add(estatus);

                    context.SaveChanges();
                }

            }

        }

    }
}