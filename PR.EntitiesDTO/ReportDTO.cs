using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PR.EntitiesDTO
{
    public class ReportDTO
    {
        public int Id { get; set; }

        [Display(Name = "ReportsCount")]
        public int ReportsCount { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        [Display(Name = "CarNumber")]
        [Required(ErrorMessage = "Car Number must be defined")]
        public string CarNumber { get; set; }

        [Display(Name = "Violation")]
        [Required(ErrorMessage = "Violation must be defined")]
        public string Violation { get; set; }

        [Display(Name = "AssignedComment")]
        public string AssignedComment { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        public ReportStatusDTO Status { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        public string UserId { get; set; }

        public ICollection<IFormFile> AttachedFiles { get; set; }
    }
}
