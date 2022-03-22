using LoadDistribution.Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace LoadDistribution.Core.Interfaces
{
    public interface IDbContext
    {
        DatabaseFacade Database { get; }
        ChangeTracker ChangeTracker { get; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class, IEntity;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
