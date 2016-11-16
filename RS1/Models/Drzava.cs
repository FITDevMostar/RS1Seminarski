using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class Drzava
    {
        public Drzava()
        {
            Gradovi = new List<Grad>();
        }

        public int DrzavaId { get; set; }
        public string Naziv { get; set; }

        public virtual List<Grad> Gradovi { get; set; }
    }
}