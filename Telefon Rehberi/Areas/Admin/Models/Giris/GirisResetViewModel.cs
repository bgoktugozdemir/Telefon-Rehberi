using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Telefon_Rehberi.Areas.Admin.Models.Giris
{
    public class GirisResetViewModel
    {
        public string oldPass { get; set; }
        public string newPass { get; set; }
        public string newPass2 { get; set; }
    }
}