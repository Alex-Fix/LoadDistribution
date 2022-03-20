using LoadDistribution.Core.Domain.Enums;
using LoadDistribution.Core.Domain.Interfaces;
using System.Collections.Generic;

namespace LoadDistribution.Core.Domain.Models
{
    public class Activity : BaseProjectRelatedEntity
    {
        #region Properties
        public string Name { get; set; }
        public DependencyType DependencyType { get; set; }

        // navigation properties
        public virtual ICollection<DisciplineActivityMap> DisciplineActivityMaps { get; set; }
        #endregion

        #region Methods
        public override void CleanNavigationProperties()
        {
            base.CleanNavigationProperties();
            DisciplineActivityMaps = null;
        }
        #endregion
    }
}
