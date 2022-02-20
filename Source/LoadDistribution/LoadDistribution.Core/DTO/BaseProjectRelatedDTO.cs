namespace LoadDistribution.Core.DTO
{
    public abstract class BaseProjectRelatedDTO : BaseDTO, IProjectRelatedDTO
    {
        public int ProjectId { get; set; }
    }
}
