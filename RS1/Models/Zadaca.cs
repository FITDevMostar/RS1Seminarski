using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class Zadaca
    {
        public int ZadacaId { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public int MaxPoints { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime Rok { get; set; }

        public int KursId { get; set; }
        public Kurs Kurs { get; set; }
    }
}