namespace LoadDistribution.Core.Domain.Models
{
    public class UniversityLecturerMap : BaseProjectRelatedEntity
    {
        public int UniversityId { get; set; }
        public int LecturerId { get; set; }

        // navigation properties
        public virtual University University { get; set; }
        public virtual Lecturer Lecturer { get; set; }
    }
}
