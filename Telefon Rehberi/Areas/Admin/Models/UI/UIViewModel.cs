using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Rehber.Model.DataModel;

namespace Telefon_Rehberi.Areas.Admin.Models.UI
{
    public class UIViewModel
    {
        public List<tblCalisan> CalisanList { get; set; }
        public List<tblDepartman> DepartmanList { get; set; }
    }
}