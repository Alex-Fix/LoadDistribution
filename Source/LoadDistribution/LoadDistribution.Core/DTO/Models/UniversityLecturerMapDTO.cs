namespace LoadDistribution.Core.DTO.Models
{
    public class UniversityLecturerMapDTO : BaseProjectRelatedDTO
    {
        public virtual UniversityDTO University { get; set; }
        public virtual LecturerDTO Lecturer { get; set; }
    }
}
