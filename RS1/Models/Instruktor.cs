using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class Instruktor
    {
        public Instruktor()
        {
            Kursevi = new List<Kurs>();
            Odgovori = new List<Odgovor>();
        }

        public string Id { get; set; }
        public AppUser AppUser { get; set; }

        public virtual List<Kurs> Kursevi { get; set; }
        public virtual List<Odgovor> Odgovori { get; set; }
    }
}