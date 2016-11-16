using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class Odgovor
    {   
        public Odgovor()
        {
            StudentPitanje = new List<StudentPitanje>();
        }

        public int OdgovorId { get; set; }
        public string OdgovorNaziv { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime DatumNapisan { get; set; }

        public string InstruktorId { get; set; }
        public Instruktor Instruktor { get; set; }

        public virtual List<StudentPitanje> StudentPitanje { get; set; }

    }
}