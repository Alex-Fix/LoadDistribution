using LoadDistribution.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace LoadDistribution.Core.Domain
{
    public interface IDbContext
    {
        DbSet<Log> Logs { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
