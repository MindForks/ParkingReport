using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PR.Entities
{
    public class Report
    {
        public Report()
        {
            AttachedFiles = new List<AttachedFile>();
        } 
        public int Id { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }

        [Display(Name = "Car number")]
        public string CarNumber { get; set; }

        [Display(Name = "Violation")]
        [Required(ErrorMessage = "Violation must be defined")]
        public string Violation { get; set; }

        [Display(Name = "Assigned Comment")]
        public string AssignedComment { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        public ReportStatus Status { get; set; }
        public int StatusId { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }

        public ICollection<AttachedFile> AttachedFiles { get; set; }

    }
}
