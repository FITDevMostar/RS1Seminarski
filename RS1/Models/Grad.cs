using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class Grad
    {

        public Grad()
        {
            AppUsers = new List<AppUser>();
        }

        public int GradId { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }

        public int? DrzavaId { get; set; }
        public Drzava Drzava { get; set; }

        public virtual List<AppUser> AppUsers { get; set; } // virtual if we want lazy loading
    }
}