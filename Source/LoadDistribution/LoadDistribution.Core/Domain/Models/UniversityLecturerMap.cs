namespace LoadDistribution.Core.Domain.Models
{
    public class UniversityLecturerMap : BaseEntity
    {
        public int UniversityId { get; set; }
        public int LectureId { get; set; }
        
        // navigation properties
        public virtual University University { get; set; }
        public virtual Lecturer Lecturer { get; set; }
    }
}
