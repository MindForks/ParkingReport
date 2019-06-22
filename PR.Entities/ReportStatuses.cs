using System;
using System.Collections.Generic;
using System.Text;

namespace PR.Entities
{
    public enum ReportStatuses : int
    {
        Created = 1,
        InProgress = 2,
        FalseIncident = 3,
        CarAbsent = 4,
        Fixed = 5
    }
}
