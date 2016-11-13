using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RS1.ViewModel
{
    public class LoginModel
    {
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password{ get; set; }

    }
}