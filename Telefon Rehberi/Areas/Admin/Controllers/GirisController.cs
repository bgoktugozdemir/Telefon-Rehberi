using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Rehber.Bl.Interface;
using Telefon_Rehberi.Areas.Admin.Models.Giris;

namespace Telefon_Rehberi.Areas.Admin.Controllers
{
    public class GirisController : Controller
    {
        private IAyarlarYonetimi _ayarlarYonetimi;

        public GirisController(IAyarlarYonetimi ayarlarYonetimi)
        {
            _ayarlarYonetimi = ayarlarYonetimi;
        }

        // GET: Admin/Giris
        public ActionResult Index(string pass)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "UI");
            }
            else
            {
                if (!String.IsNullOrEmpty(pass))
                {
                    GirisViewModel model = new GirisViewModel()
                    {
                        Pass = pass
                    };
                    return View(model);
                }
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(GirisViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Pass == _ayarlarYonetimi.Get(a => a.Anahtar == "AdminPass").Deger)
                {
                    Session["UserName"] = "Admin";
                    return RedirectToAction("Index", "UI");
                }
            }

            this.ErrorMessage("Şifre yanlış!");
            return RedirectToAction("Index");
        }

        public ActionResult Cikis()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "Giris");
        }
    }
}