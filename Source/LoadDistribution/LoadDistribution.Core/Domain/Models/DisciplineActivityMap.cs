﻿using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models
{
    public class DisciplineActivityMap : BaseEntity
    {
        public int DisciplineId { get; set; }
        public int ActivityId { get; set; }

        // navigation properties
        public virtual Discipline Discipline { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual ICollection<LecturerDisciplineActivityMap> LecturerDisciplineActivityMaps { get; set; }
    }
}
