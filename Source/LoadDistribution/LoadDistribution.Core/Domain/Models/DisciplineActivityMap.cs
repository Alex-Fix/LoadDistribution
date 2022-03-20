using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models
{
    public class DisciplineActivityMap : BaseProjectRelatedEntity
    {
        #region Properties
        public int DisciplineId { get; set; }
        public int ActivityId { get; set; }

        // navigation properties
        public virtual Discipline Discipline { get; set; }
        public virtual Activity Activity { get; set; }
        public virtual ICollection<LecturerDisciplineActivityMap> LecturerDisciplineActivityMaps { get; set; }
        #endregion

        #region Methods
        public override void CleanNavigationProperties()
        {
            base.CleanNavigationProperties();
            Discipline = null;
            Activity = null;
            LecturerDisciplineActivityMaps = null;
        }
        #endregion
    }
}
