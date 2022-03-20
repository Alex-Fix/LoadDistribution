using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models
{
    public class Lecturer : BaseProjectRelatedEntity
    {
        #region Properties
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        // navigation properties
        public virtual ICollection<UniversityLecturerMap> UniversityLectureMaps { get; set; }
        public virtual ICollection<LecturerDisciplineActivityMap> LecturerDisciplineActivityMaps { get; set; }
        #endregion

        #region Methods
        public override void CleanNavigationProperties()
        {
            base.CleanNavigationProperties();
            UniversityLectureMaps = null;
            LecturerDisciplineActivityMaps = null;
        }
        #endregion
    }
}
