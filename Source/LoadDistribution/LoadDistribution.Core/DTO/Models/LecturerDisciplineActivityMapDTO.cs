namespace LoadDistribution.Core.DTO.Models
{
    public class LecturerDisciplineActivityMapDTO : BaseProjectRelatedDTO
    {
        public decimal Rate { get; set; }
        public LecturerDTO Lecturer { get; set; }
        public DisciplineActivityMapDTO DisciplineActivityMap { get; set; }
    }
}
