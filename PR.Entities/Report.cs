using System;
using System.Collections.Generic;
using System.Text;

namespace PR.Entities
{
   public class Report
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string CarNumber { get; set; }
        public string Violation { get; set; }
        public string AssignedComment { get; set; }
        public DateTimeOffset CreationTime { get; set; }

        public ReportStatus Status { get; set; }
        public int StatusId { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }

        public ICollection<AttachedFile> AttachedFiles { get; set; }

    }
}
