using System;
using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        // navigation properties
        public virtual ICollection<University> Universities { get; set; }
    }
}
