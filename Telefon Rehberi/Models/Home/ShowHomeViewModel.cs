using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rehber.Model.DataModel;

namespace Telefon_Rehberi.Models.Home
{
    public class ShowHomeViewModel
    {
        public tblCalisan Calisan { get; set; }
        public tblDepartman Departman { get; set; }
    }
}