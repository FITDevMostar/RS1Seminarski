using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;


namespace RS1.Models
{
    public class AppUser : IdentityUser
    {
        public String Index { get; set; }
    }
}