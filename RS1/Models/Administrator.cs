using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RS1.Models
{
    public class Administrator
    {
        public Administrator()
        {
            KursArhiva = new List<KursArhiva>();
        }

        public string Id { get; set; }
        public AppUser AppUser { get; set; }

        public virtual List<KursArhiva> KursArhiva { get; set; }
    }
}