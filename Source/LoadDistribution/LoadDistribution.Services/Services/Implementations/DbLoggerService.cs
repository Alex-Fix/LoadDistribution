using LoadDistribution.Core.Domain.Enums;
using LoadDistribution.Core.Domain.Models;
using LoadDistribution.Services.Repositories;
using System;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Services.Implementations
{
    public class DbLoggerService : ILoggerService
    {
        #region Fields
        private readonly ILogRepository _logRepository;
        #endregion

        #region Constructors
        public DbLoggerService(ILogRepository logRepository)
        {
            _logRepository = logRepository ?? throw new ArgumentException(nameof(logRepository));
        }
        #endregion

        #region Methods
        public async Task Exception(Exception ex, string message)
        {
            if(ex is null)
            {
                throw new ArgumentNullException(nameof(ex));
            }
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            var log = new Log
            {
                CreatedUtc = DateTime.UtcNow,
                Type = LogType.Exception,
                ExceptionType = ex.GetType().FullName,
                Message = message,
                Details = ex.ToString()
            };

            await _logRepository.Insert(log);
        }
        #endregion
    }
}
