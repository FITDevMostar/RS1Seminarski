using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class Kurs
    {
        public Kurs()
        {
            StudentKurs = new List<StudentKurs>();
            Zadace = new List<Zadaca>();
            Pitanje = new List<Pitanje>();
            Biljeske = new List<KursBiljeske>();
            KursArhiva = new List<KursArhiva>();
            Kategorija = new List<PodKategorija>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime DateCreated { get; set; }
        public string Dificulty { get; set; }
        public bool isArhiviran { get; set; }
        public string videoLink { get; set; }
        public string Description { get; set; }    

        public string InstruktorId { get; set; }
        public Instruktor Instruktor { get; set; }

        public virtual List<StudentKurs> StudentKurs { get; set; }
        public virtual List<Zadaca> Zadace { get; set; }
        public virtual List<Pitanje> Pitanje { get; set; }
        public virtual List<KursBiljeske> Biljeske { get; set; }
        public virtual List<KursArhiva> KursArhiva { get; set; }
        public virtual List<PodKategorija> Kategorija { get; set; } 

    }
}