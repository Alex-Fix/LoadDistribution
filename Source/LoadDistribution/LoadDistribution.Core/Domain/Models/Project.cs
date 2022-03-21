using LoadDistribution.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        // navigation properties
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
        public virtual ICollection<DisciplineActivityMap> DisciplineActivityMaps { get; set; }
        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public virtual ICollection<LecturerDisciplineActivityMap> LecturerDisciplineActivityMaps { get; set; }
        public virtual ICollection<University> Universities { get; set; }
        public virtual ICollection<UniversityLecturerMap> UniversityLecturerMaps { get; set; }
    }
}
