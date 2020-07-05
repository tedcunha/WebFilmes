using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tapioca.HATEOAS;
using WebFilmes.Business;
using WebFilmes.Business.Implementations;
using WebFilmes.HyperMidia;
using WebFilmes.Model.Context;
using WebFilmes.Repository.Generic;

namespace WebFilmes
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Conectando com o Banco
            var connectioString = Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySqlContext>(options => options.UseMySql(connectioString));

            services.AddControllers();

            #region "HATOAS"
            //HATOAS
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new FilmesEnricher());
            services.AddSingleton(filterOptions);
            #endregion

            services.AddApiVersioning();

            #region "INJEÇÃO DE DEPENDENCIA"
            // Business
            services.AddScoped<IFilmesBusiness,FilmesBusinessImpl>();

            // Repository
            services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
       
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller=Values}/{id?}");
            });
        }
    }
}
