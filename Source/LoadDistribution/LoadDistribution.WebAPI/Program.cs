using LoadDistribution.WebAPI;
using Microsoft.AspNetCore.Builder;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

WebApplication application = builder.Build();

startup.Configure(application, application.Environment);

await application.RunAsync();