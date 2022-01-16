using LoadDistribution.Core.Domain;
using LoadDistribution.Core.Domain.Enums;
using LoadDistribution.Core.Domain.Models;
using System;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Services.Implementations
{
    public class DbLoggerService : ILoggerService
    {
        #region Private Properties
        private readonly IDbContext _dbContext;
        #endregion

        #region Constructors
        public DbLoggerService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Public Methods
        public async Task LogExceptionAsync(Exception exception, string message)
        {
            if(exception is null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            var log = new Log
            {
                CreatedUtc = DateTime.UtcNow,
                Message = message ?? string.Empty,
                Details = exception.ToString(),
                Type = LogType.Exception,
                ExceptionType = exception.GetType().ToString()
            };

            await _dbContext.Logs.AddAsync(log);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
