using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PR.Entities
{
    public class User : IdentityUser
    {
        public bool IsBanned { get; set; }

        public ICollection<Report> Reports { get; set; }

        public bool IsNumberAproved { get; set; }

        public string Plate { get; set; }
    }
}
