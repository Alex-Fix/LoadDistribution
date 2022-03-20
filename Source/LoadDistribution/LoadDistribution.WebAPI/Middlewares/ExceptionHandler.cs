using LoadDistribution.Services.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LoadDistribution.WebAPI.Middlewares
{
    public class ExceptionHandler
    {
        #region Fields
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ExceptionHandler> _logger;
        #endregion

        #region Constructors
        public ExceptionHandler(
            RequestDelegate next,
            IWebHostEnvironment webHostEnvironment,
            ILogger<ExceptionHandler> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _webHostEnvironment = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        #endregion

        #region Methods
        public async Task InvokeAsync(HttpContext context, ILoggerService loggerService)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, nameof(ExceptionHandler));
                await loggerService.Exception(ex, nameof(InvokeAsync));

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                if (_webHostEnvironment.IsDevelopment())
                {
                    await context.Response.WriteAsync(ex.ToString());
                }
            }
        }
        #endregion
    }
}
