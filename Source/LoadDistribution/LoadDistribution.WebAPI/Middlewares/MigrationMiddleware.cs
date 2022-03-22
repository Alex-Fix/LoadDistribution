using LoadDistribution.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        public async Task InvokeAsync(HttpContext context, IDbContext dbContext)
        {
            await dbContext.Database.MigrateAsync();
            await _next(context);
        }
        #endregion
    }
}
