﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GpoSion.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            ConfigureServices(services);
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCors();
            services.AddAutoMapper(typeof(GpoSionRepository).Assembly);
            services.AddScoped<IGpoSionRepository, GpoSionRepository>();
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
