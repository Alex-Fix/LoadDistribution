namespace LoadDistribution.Core.DTO.Models
{
    public class UniversityLecturerMapDTO : BaseProjectRelatedDTO
    {
        public int UniversityId { get; set; }
        public int LecturerId { get; set; }
        public virtual UniversityDTO University { get; set; }
        public virtual LecturerDTO Lecturer { get; set; }
    }
}
