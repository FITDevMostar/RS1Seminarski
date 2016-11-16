using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class PodKategorija
    {
        public PodKategorija()
        {
            Kurs = new List<Kurs>();
        }

        public int PodKategorijaId { get; set; }
        public string Naziv { get; set; }

        public int KategorijaId { get; set; }
        public Kategorija Kategorija { get; set; }

        public virtual List<Kurs> Kurs { get; set; }
    }
}