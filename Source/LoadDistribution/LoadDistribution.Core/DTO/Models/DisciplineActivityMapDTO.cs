namespace LoadDistribution.Core.DTO.Models
{
    public class DisciplineActivityMapDTO : BaseProjectRelatedDTO
    {
        public DisciplineDTO Discipline { get; set; }
        public ActivityDTO Activity { get; set; }
    }
}
