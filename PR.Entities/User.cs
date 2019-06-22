using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PR.Entities
{
    public class User : IdentityUser
    {
        public ICollection<Report> Reports { get; set; }
    }
}
