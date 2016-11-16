using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class StudentPitanje
    {
        [Key, Column(Order = 0)]
        public string StudentId { get; set; }
        [Key, Column(Order = 1)]
        public int PitanjeId { get; set; }
        [Key, Column(Order = 2)]
        public int OdgovorId { get; set; }

        public Student Student { get; set; }
        public Pitanje Pitanje { get; set; }
        public Odgovor Odgovor { get; set; }

    }
}