namespace LoadDistribution.Core.Helpers.Models
{
    public class InsertResult
    {
        #region Constructors
        public InsertResult(int? id, bool success)
        {
            Id = id;
            Success = success;
        }
        #endregion

        #region Properties
        public int? Id { get; set; }
        public bool Success { get; set; }
        #endregion
    }
}
