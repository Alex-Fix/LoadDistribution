namespace LoadDistribution.Core.DTO.Models
{
    public class LecturerDisciplineActivityMapDTO : BaseProjectRelatedDTO
    {
        public int LecturerId { get; set; }
        public int DisciplineId { get; set; }
        public int ActivityId { get; set; }
        public decimal Rate { get; set; }
        
        public LecturerDTO Lecturer { get; set; }
        public DisciplineDTO Discipline { get; set; }
        public ActivityDTO Activity { get; set; }
    }
}
