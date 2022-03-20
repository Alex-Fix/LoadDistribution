namespace LoadDistribution.Core.Domain.Models
{
    public class UniversityLecturerMap : BaseProjectRelatedEntity
    {
        #region Properties
        public int UniversityId { get; set; }
        public int LectureId { get; set; }

        // navigation properties
        public virtual University University { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        #endregion

        #region Methods
        public override void CleanNavigationProperties()
        {
            base.CleanNavigationProperties();
            University = null;
            Lecturer = null;
        }
        #endregion
    }
}
