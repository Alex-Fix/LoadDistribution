using System.Collections.Generic;

namespace LoadDistribution.Core.Helpers.Models
{
    public class BulkInsertResult
    {
        #region Constructors
        public BulkInsertResult(List<int> ids, bool success)
        {
            Ids = ids;
            Success = success;
        }
        #endregion

        #region Properties
        public List<int> Ids { get; set; }
        public bool Success { get; set; }
        #endregion
    }
}
