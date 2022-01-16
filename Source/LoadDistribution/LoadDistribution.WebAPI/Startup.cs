using LoadDistribution.Core.Domain;
using LoadDistribution.Core.Options;
using LoadDistribution.Data;
using LoadDistribution.Services.Services;
using LoadDistribution.Services.Services.Implementations;
using LoadDistribution.WebAPI.Middlewarese;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace LoadDistribution.WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MySqlDbOptions>(_configuration.GetSection(nameof(MySqlDbOptions)));
            
            services.AddDbContext<IDbContext, MySqlDbContext>();

            services.AddScoped<ILoggerService, DbLoggerService>();

            services.AddControllers().AddNewtonsoftJson();

            services.AddSpaStaticFiles(cfg =>
            {
                cfg.RootPath = Path.Combine("ClientApp", "dist");
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionHandler>();

            app.UseHsts();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseEndpoints(cfg => cfg.MapControllers());
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
