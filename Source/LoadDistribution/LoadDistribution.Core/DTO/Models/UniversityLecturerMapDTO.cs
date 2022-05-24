namespace LoadDistribution.Core.DTO.Models;

public class UniversityLecturerMapDTO : BaseProjectRelatedDTO
{
      public int UniversityId { get; set; }
      public int LecturerId { get; set; }
      public UniversityDTO? University { get; set; }
      public LecturerDTO? Lecturer { get; set; }
}
