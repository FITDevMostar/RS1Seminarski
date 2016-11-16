using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class StudentKurs
    {

        [Key, Column(Order = 0)]
        public string StudentId { get; set; }
        [Key, Column(Order = 1)]
        public int KursId { get; set; }
        
        public Student Student { get; set; }
        public Kurs Kurs { get; set; }

        [Column(TypeName ="datetime")]
        public DateTime DatumPocetak { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DatumKraj { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DatumZavrsen { get; set; } // kad je student zavrsio kurs

        public int Ocjena { get; set; }

        public int? KursLajkId { get; set; }
        public KursLajk KursLajk { get; set; }

        public int? StudentZadacaId { get; set; }
        public StudentZadaca StudentZadaca { get; set; }

    }
}