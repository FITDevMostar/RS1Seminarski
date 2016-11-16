using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class KursBiljeske
    {
        public int KursBiljeskeId { get; set; }
        public string Biljeska { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DatumKreiran { get; set; }

        public int KursId { get; set; }
        public Kurs Kurs { get; set; }
    }
}