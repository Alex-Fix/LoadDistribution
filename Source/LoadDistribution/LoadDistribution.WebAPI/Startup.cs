using LoadDistribution.Core.AutoMapperProfiles;
using LoadDistribution.Core.Options;
using LoadDistribution.Data;
using LoadDistribution.Services.Facades;
using LoadDistribution.Services.Facades.Implementations;
using LoadDistribution.Services.Repositories;
using LoadDistribution.Services.Repositories.Implementations;
using LoadDistribution.Services.Services;
using LoadDistribution.Services.Services.Implementations;
using LoadDistribution.WebAPI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LoadDistribution.Core.Interfaces;

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

            services.AddAutoMapper(typeof(DomainToDTOProfile), typeof(HelperProfile));

            services.AddDbContext<IDbContext, SQLiteDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(SQLiteRepository<>));
            services.AddScoped(typeof(ICollectionRepository<>), typeof(SQLiteCollectionRepository<>));
            services.AddScoped(typeof(IProjectRelatedCollectionRepository<>), typeof(SQLiteProjectRelatedCollectionRepository<>));

            services.AddScoped<ILoggerService, DbLoggerService>();

            services.AddScoped(typeof(IFacade<,>), typeof(Facade<,>));
            services.AddScoped(typeof(ICollectionFacade<,>), typeof(CollectionFacade<,>));
            services.AddScoped(typeof(IProjectRelatedCollectionFacade<,>), typeof(ProjectRelatedCollectionFacade<,>));

            services.AddControllers().AddNewtonsoftJson();
            services.AddSpaStaticFiles(cfg =>
            {
                cfg.RootPath = Path.Combine("ClientApp", "dist");
            });
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<MigrationMiddleware>();
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
            app.UseCors(opt => opt.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseEndpoints(cfg => cfg.MapControllers());
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
            });
        }
    }
}
