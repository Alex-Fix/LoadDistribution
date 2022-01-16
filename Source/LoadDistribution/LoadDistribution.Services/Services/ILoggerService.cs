using System;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Services
{
    public interface ILoggerService
    {
        Task LogExceptionAsync(Exception exception, string message);
    }
}
