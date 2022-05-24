using LoadDistribution.Core.Domain.Enums;
using LoadDistribution.Core.DTO.Interfaces;
using System;

namespace LoadDistribution.Core.DTO.Models;

public class LogDTO : IDTO
{
      public int Id { get; set; }
      public DateTimeOffset Created { get; set; }
      public string Message { get; set; } = string.Empty;
      public string? Details { get; set; }
      public LogType Type { get; set; }
      public string? ExceptionType { get; set; }
}
