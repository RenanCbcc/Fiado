using System;
using Fiado.Models.ClienteModelos;
using Fiado.Models.ContaModelos;
using Fiado.Models.NotaModelos;
using Fiado.Models.PagamentoModelos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fiado
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment environment;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            this.configuration = configuration;
            this.environment = environment;

        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            //DB
            services.AddDbContextPool<FiadoContexto>(options =>
            {
                if (environment.IsDevelopment())
                {
                    options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));
                }
                if (environment.IsProduction())
                {
                    var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
                    options.UseNpgsql(connectionString);
                    //options.UseNpgsql(configuration.GetConnectionString("PostgresConnection"));
                }

            });

            services.AddControllersWithViews();

            //Injecao de dependencias
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<INotaRepositorio, NotaRepositorio>();
            services.AddScoped<IContaRepositorio, ContaRepositorio>();
            services.AddScoped<IPagamentoRepositorio, PagamentoRepositorio>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (this.environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Conta}/{action=Lista}/{id?}");
            });

        }
    }
}
