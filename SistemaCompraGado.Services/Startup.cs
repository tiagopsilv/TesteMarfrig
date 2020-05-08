using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SistemaCompraGado.Application;
using SistemaCompraGado.Application.Interfaces;
using SistemaCompraGado.Domain.Interfaces.Repository;
using SistemaCompraGado.Domain.Interfaces.Services;
using SistemaCompraGado.Domain.Interfaces.Validar;
using SistemaCompraGado.Domain.Services;
using SistemaCompraGado.Domain.Validar;
using SistemaCompraGado.Infra.Data.Contexto;
using SistemaCompraGado.Infra.Data.Repositories;
using SistemaCompraGado.Services.Models;
using SistemaCompraGado.Services.Models.Interfaces;
using Microsoft.OpenApi.Models;

namespace SistemaCompraGado.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddTransient<IPecuaristaAppService, PecuaristaAppService>();
            services.AddScoped<IPecuaristaAppService, PecuaristaAppService>();
            services.AddScoped<IPecuaristaService, PecuaristaService>();
            services.AddScoped<IPecuaristaRepository, PecuaristaRepository>();
            services.AddScoped<ISistemaCompraGadoDGContexto, SistemaCompraGadoDGContexto>();
            services.AddTransient<IAnimalAppService, AnimalAppService>();
            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<IAnimalRepository, AnimalRepository>();
            services.AddScoped<ICompraGadoAppService, CompraGadoAppService>();
            services.AddScoped <ICompraGadoService, CompraGadoService>();
            services.AddScoped <ICompraGadoRepository, CompraGadoRepository>();
            services.AddScoped <ICompraGadoItemRepository, CompraGadoItemRepository>();
            services.AddScoped <ICompraGadoValidar, CompraGadoValidar>();
            services.AddScoped<ICompraGadoModel, CompraGadoModel>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Sistema de Compra de Gado",
                    Description = "Sistema que permita realizar a manutenção de registros de compras de gado e a impressão delas em forma de relatório.",
                    Contact = new OpenApiContact
                    {
                        Name = "Tiago Pereira da Silva",
                        Email = "tiagosilv@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/tiagopsilvatec/"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Tiago Pereira da Silva",
                        Url = new Uri("https://www.linkedin.com/in/tiagopsilvatec/"),
                    }
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema de Compra de Gado");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
