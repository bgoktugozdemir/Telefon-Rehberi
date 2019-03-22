using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rehber.Model.DataModel;

namespace Telefon_Rehberi.Areas.Admin.Models.CalisanYonetim
{
    public class CalisanDuzenleViewModel
    {
        public tblCalisan Calisan { get; set; }
        public List<tblCalisan> CalisanList { get; set; }
        public List<tblDepartman> DepartmanList { get; set; }
        public SelectList CalisanSelectList { get; set; }
    }
}