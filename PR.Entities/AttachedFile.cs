using System;
using System.Collections.Generic;
using System.Text;

namespace PR.Entities
{
    public class AttachedFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public Report Report { get; set; }
        public int ReportId { get; set; }

    }
}
