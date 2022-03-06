using LoadDistribution.Core.Domain.Enums;
using System;

namespace LoadDistribution.Core.Domain.Models
{
    public class Log : IEntity
    {
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public LogType Type { get; set; }
        public string ExceptionType { get; set; }
    }
}
