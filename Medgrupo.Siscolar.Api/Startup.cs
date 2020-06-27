using Medgrupo.Siscolar.Domain.Handlers;
using Medgrupo.Siscolar.Domain.Repositories;
using Medgrupo.Siscolar.Infra.Contexts;
using Medgrupo.Siscolar.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Medgrupo.Siscolar.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {           

            services.AddDbContext<SiscolarDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SiscolarDbConnection"));
            });            


            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedGrupo Siscolar OnLine Documentation", Version = "v1" });
            });

            //Handlers
            services.AddTransient<SchoolHandler, SchoolHandler>();
            services.AddTransient<SchoolClassHandler, SchoolClassHandler>();
            //Data
            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<ISchoolClassRepository, SchoolClassRepository>();
            services.AddTransient<SiscolarDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Siscolar V1");
            });

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
