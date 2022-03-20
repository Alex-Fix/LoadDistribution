using LoadDistribution.Core.Domain.Interfaces;
using System;

namespace LoadDistribution.Core.Domain.Models
{
    public abstract class BaseProjectRelatedEntity : BaseEntity, IProjectRelatedEntity, INavigationCleanable
    {
        #region Properties
        public int ProjectId { get; set; }

        // navigation properties
        public virtual Project Project { get; set; }
        #endregion

        #region Methods
        public virtual void CleanNavigationProperties()
        {
            Project = null;
        }
        #endregion
    }
}
