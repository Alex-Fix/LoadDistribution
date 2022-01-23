using LoadDistribution.Core.Domain;
using LoadDistribution.Core.Options;
using LoadDistribution.Data;
using LoadDistribution.Services.Services;
using LoadDistribution.Services.Services.Implementations;
using LoadDistribution.WebAPI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.IO;
using System.Linq;

namespace LoadDistribution.WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly string[] _languages = new[] { "uk-UA" };

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(opt => opt.ResourcesPath = "Resources");

            services.Configure<SQLiteDbOptions>(_configuration.GetSection(nameof(SQLiteDbOptions)));

            services.AddDbContext<IDbContext, SQLiteDbContext>();

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

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(_languages.First()),
                SupportedCultures = _languages.Select(l => new CultureInfo(l)).ToList()
            });

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
