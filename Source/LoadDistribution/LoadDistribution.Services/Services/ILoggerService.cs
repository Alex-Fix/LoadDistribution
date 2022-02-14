using System;
using System.Threading.Tasks;

namespace LoadDistribution.Services.Services
{
    public interface ILoggerService
    {
        Task Exception(Exception ex, string message);
    }
}
