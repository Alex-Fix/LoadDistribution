using LoadDistribution.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace LoadDistribution.WebAPI.Middlewares
{
    public class MigrationMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;
        #endregion

        #region Constructors
        public MigrationMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }
        #endregion

        #region Methods
        public async Task InvokeAsync(HttpContext context, SQLiteDbContext dbContext)
        {
            await dbContext.Database.MigrateAsync();
            await _next(context);
        }
        #endregion
    }
}
