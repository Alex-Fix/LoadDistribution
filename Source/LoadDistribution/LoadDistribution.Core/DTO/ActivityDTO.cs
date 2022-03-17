﻿using LoadDistribution.Core.Domain.Enums;

namespace LoadDistribution.Core.DTO
{
    public class ActivityDTO : BaseProjectRelatedDTO
    {
        public string Name { get; set; }
        public DependencyType DependencyType { get; set; }
    }
}
