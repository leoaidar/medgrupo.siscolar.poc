using Medgrupo.Siscolar.Domain.Handlers;
using Medgrupo.Siscolar.Domain.Repositories;
using Medgrupo.Siscolar.Infrastructure.Contexts;
using Medgrupo.Siscolar.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddControllers();

            services.AddDbContext<SiscolarDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SiscolarDbConnection"));
            });            

            services.AddTransient<ISchoolRepository, SchoolRepository>();
            services.AddTransient<SchoolHandler, SchoolHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

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
