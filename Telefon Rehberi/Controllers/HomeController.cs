using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rehber.Bl.Interface;
using Telefon_Rehberi.Models.Home;

namespace Telefon_Rehberi.Controllers
{
    public class HomeController : Controller
    {
        private ICalisanYonetimi _calisanYonetimi;
        private IDepartmanYonetimi _departmanYonetimi;

        public HomeController(ICalisanYonetimi calisanYonetimi, IDepartmanYonetimi departmanYonetimi)
        {
            _calisanYonetimi = calisanYonetimi;
            _departmanYonetimi = departmanYonetimi;
        }

        // GET: Home
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.CalisanList = _calisanYonetimi.GetAll().OrderBy(c => c.Ad).ThenBy(c => c.Soyad).ToList();

            return View(model);
        }

        public ActionResult CalisanGetir(int id)
        {
            ShowHomeViewModel model = new ShowHomeViewModel();

            model.Calisan = _calisanYonetimi.Get(c => c.ID == id);
            model.Departman = _departmanYonetimi.Get(d => d.ID == model.Calisan.DepartmanID);
            return PartialView(model);
        }
    }
}