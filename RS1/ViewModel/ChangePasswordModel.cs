using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RS1.ViewModel
{
    public class ChangePasswordModel
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public bool isLoged { get; set; }
    }
}