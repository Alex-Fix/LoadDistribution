namespace LoadDistribution.Core.Domain.Models
{
    public interface IProjectRelatedEntity : IEntity
    {
        int ProjectId { get; set; }
    }
}
