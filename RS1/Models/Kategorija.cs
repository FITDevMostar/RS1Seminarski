using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class Kategorija
    {
        public Kategorija()
        {
            PodKategorije = new List<PodKategorija>();
        }

        public int KategorijaId { get; set; }
        public string Naziv { get; set; }

        public virtual List<PodKategorija> PodKategorije { get; set; }
    }
}