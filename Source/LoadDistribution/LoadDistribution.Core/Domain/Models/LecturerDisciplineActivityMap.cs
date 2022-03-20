namespace LoadDistribution.Core.Domain.Models
{
    public class LecturerDisciplineActivityMap : BaseProjectRelatedEntity
    {
        #region Properties
        public int LecturerId { get; set; }
        public int DisciplineActivityMapId { get; set; }
        public decimal Rate { get; set; }

        // navigation properties
        public virtual Lecturer Lecturer { get; set; }
        public virtual DisciplineActivityMap DisciplineActivityMap { get; set; }
        #endregion

        #region Methods
        public override void CleanNavigationProperties()
        {
            base.CleanNavigationProperties();
            Lecturer = null;
            DisciplineActivityMap = null;
        }
        #endregion
    }
}
