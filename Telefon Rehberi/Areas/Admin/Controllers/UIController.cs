using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rehber.Bl.Interface;
using Telefon_Rehberi.Areas.Admin.Models.UI;

namespace Telefon_Rehberi.Areas.Admin.Controllers
{
    public class UIController : Controller
    {
        private ICalisanYonetimi _calisanYonetimi;
        private IDepartmanYonetimi _departmanYonetimi;

        public UIController(ICalisanYonetimi calisanYonetimi, IDepartmanYonetimi departmanYonetimi)
        {
            _calisanYonetimi = calisanYonetimi;
            _departmanYonetimi = departmanYonetimi;
        }

        // GET: Admin/UI
        public ActionResult Index()
        {
            UIViewModel model = new UIViewModel();
            model.CalisanList = _calisanYonetimi.GetAll().OrderBy(c => c.Ad).ThenBy(c => c.Soyad).ToList();
            model.DepartmanList = _departmanYonetimi.GetAll().OrderByDescending(d => d.tblCalisan.Count).ThenBy(d => d.Ad).ToList();

            return View(model);
        }
    }
}