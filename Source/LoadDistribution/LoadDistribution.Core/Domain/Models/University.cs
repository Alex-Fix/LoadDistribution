using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models
{
    public class University : BaseProjectRelatedEntity
    {
        #region Properties
        public string Name { get; set; }

        // navigation properties
        public virtual ICollection<UniversityLecturerMap> UniversityLectureMaps { get; set; }
        public virtual ICollection<Discipline> Disciplines { get; set; }
        #endregion

        #region Methods
        public override void CleanNavigationProperties()
        {
            base.CleanNavigationProperties();
            UniversityLectureMaps = null;
            Disciplines = null;
        }
        #endregion
    }
}
