using LoadDistribution.Core.Domain.Enums;
using System;

namespace LoadDistribution.Core.Domain.Models
{
    public class Log : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedUtc { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public LogType Type { get; set; }
        public string TypeStr 
        { 
            get => Type.ToString();
            set => Type = Enum.TryParse<LogType>(value, out LogType logType) ? logType : LogType.Undefined; 
        }
        public string ExceptionType { get; set; }
    }
}
