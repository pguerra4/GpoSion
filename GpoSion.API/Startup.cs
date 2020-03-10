using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Helpers;
using GpoSion.API.Models;
using Korzh.EasyQuery.Services;
using Korzh.EasyQuery.EntityFrameworkCore;
using Korzh.Utils;
using Korzh.EasyQuery.Db;
using Korzh.EasyQuery.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace GpoSion.API
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
            Korzh.EasyQuery.AspNetCore.License.Key = "2omzL3uk_4aUjzHtUdyjYImuCUpayqVK75lJJLpSWUoDHUE305I";
            Korzh.EasyQuery.AspNetCore.JSLicense.Key = "0uo6BQcy_pU-eeWAgzISFG32v1ACiIboqH0qzo35snsBFJKG1WV";
        }

        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseLazyLoadingProxies().UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            ConfigureServices(services);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEasyQuery().UseSqlManager();

            IdentityBuilder builder = services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<DataContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
                options.AddPolicy("AlmacenRole", policy => policy.RequireRole("Admin", "Almacen"));
                options.AddPolicy("ProduccionRole", policy => policy.RequireRole("Admin", "Produccion"));
                options.AddPolicy("ProduccionAlmacen", policy => policy.RequireRole("Admin", "Produccion", "Almacen"));
                options.AddPolicy("VentasAlmacen", policy => policy.RequireRole("Admin", "Ventas", "Almacen"));
                options.AddPolicy("ComprasRole", policy => policy.RequireRole("Admin", "Compras"));
                options.AddPolicy("VentasRole", policy => policy.RequireRole("Admin", "Ventas"));
                options.AddPolicy("CalidadRole", policy => policy.RequireRole("Admin", "Calidad"));
                options.AddPolicy("SistemasRole", policy => policy.RequireRole("Admin", "Sistemas"));
                options.AddPolicy("AlmacenProductoRole", policy => policy.RequireRole("Admin", "AlmacenProducto", "Almacen"));
                options.AddPolicy("AlmacenMateriaPrimaRole", policy => policy.RequireRole("Admin", "AlmacenMateriaPrima", "Almacen"));
                options.AddPolicy("AlmacenMateriaPrimaProdRole", policy => policy.RequireRole("Admin", "AlmacenMateriaPrima", "Almacen", "Produccion"));
                options.AddPolicy("AlmacenProductoProdRole", policy => policy.RequireRole("Admin", "AlmacenProducto", "Almacen", "Produccion"));
                options.AddPolicy("AlmacenProductoVentasRole", policy => policy.RequireRole("Admin", "AlmacenProducto", "Almacen", "Ventas"));
            });

            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
            services.AddAutoMapper(typeof(GpoSionRepository).Assembly);
            services.AddScoped<IGpoSionRepository, GpoSionRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseExceptionHandler(builder =>
               {
                   builder.Run(async context =>
                   {
                       context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                       var error = context.Features.Get<IExceptionHandlerFeature>();

                       if (error != null)
                       {

                           context.Response.AddApplicationError(error.Error.Message);
                           await context.Response.WriteAsync(error.Error.Message + error.Error.GetBaseException().Message);
                       }

                   });
               });
                //app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseEasyQuery(options =>
            {
                options.Endpoint = "/api/easyquery";
                options.UseDbContext<DataContext>(loaderOptions =>
                {
                    loaderOptions.HidePrimaryKeys = false;
                });
                options.UseModelTuner(model =>
                {
                    model.EntityRoot.Scan((entity) =>
                    {
                        if (entity.Id != null)
                            if (entity.Name.StartsWith("Asp"))
                            {
                                entity.UseInResult = false;
                                entity.UseInConditions = false;
                            }
                    }, (attr) =>
                                  {

                                      if (attr.ID == "DetalleEmbarque.NoParte")
                                      {
                                          attr.Caption = "NoParte";
                                          attr.DefaultEditor = model.DefaultTextEditor;
                                      }
                                  });
                });
                options.UsePaging(25);
            });
            app.UseMvc(routes =>
            {
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Fallback", action = "Index" }
                );
            });
        }
    }
}
