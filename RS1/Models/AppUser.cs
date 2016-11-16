using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace RS1.Models
{
    public class AppUser : IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public Instruktor Instruktor { get; set; }
        public Student Student { get; set; }
        public Administrator Administrator { get; set; }

        
        public int? GradId { get; set; } // grad not required (can change in future)
        public Grad Grad { get; set; }

    }
}