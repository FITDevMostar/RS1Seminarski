using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class StudentZadaca
    {
        public StudentZadaca()
        {
            StudentKurs = new List<StudentKurs>();
        }

        public int StudentZadacaId { get; set; }
        [Column(TypeName="datetime")]
        public DateTime DatumNapisan { get; set; }
        public string Rjesenje { get; set; }
        public int? Poeni { get; set; }

        public int ZadacaId { get; set; }
        public Zadaca Zadaca { get; set; }

        public virtual List<StudentKurs> StudentKurs { get; set; }
    }
}