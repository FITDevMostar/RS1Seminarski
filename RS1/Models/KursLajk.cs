using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class KursLajk
    {
        public KursLajk()
        {
            StudentKurs = new List<StudentKurs>();
        }

        public int KursLajkId { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime DatumLajkan { get; set; }
        public int Ocjena { get; set; }
        
        public virtual List<StudentKurs> StudentKurs { get; set; }
    }
}