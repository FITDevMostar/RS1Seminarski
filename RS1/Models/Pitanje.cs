using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class Pitanje
    {
        public Pitanje()
        {
            StudentPitanje = new List<StudentPitanje>();
        }

        public int PitanjeId { get; set; }
        public string PitanjeNaziv { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime DatumNapisan { get; set; }

        public int KursId { get; set; }
        public Kurs Kurs { get; set; }

        public virtual List<StudentPitanje> StudentPitanje { get; set; }
    }
}