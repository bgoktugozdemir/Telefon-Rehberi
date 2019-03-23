using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Rehber.Bl.Interface;
using Telefon_Rehberi.Areas.Admin.Models.Giris;
using Telefon_Rehberi.Helpers;

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

            return RedirectToAction("Index", "Home", new { Area = "" });
        }

        [UserAuthorize]
        public ActionResult Reset()
        {
            GirisResetViewModel model = new GirisResetViewModel();

            return View(model);
        }

        [HttpPost]
        [UserAuthorize]
        public ActionResult Reset(GirisResetViewModel model)
        {
            try
            {
                if (model.newPass == model.newPass2)
                {
                    var Pass = _ayarlarYonetimi.Get(a => a.Anahtar == "AdminPass");
                    if (model.oldPass == Pass.Deger)
                    {
                        if (model.oldPass != model.newPass)
                        {
                            Pass.Deger = model.newPass;
                            _ayarlarYonetimi.Update(Pass);

                            this.SuccessMessage("Admin şifresi başarıyla değiştirildi.");
                            return RedirectToAction("Index", "UI");
                        }
                        else
                        {
                            this.WarningMessage("Yeni şifre eski şifreden farklı olmalıdır!");
                        }
                    }
                    else
                    {
                        this.WarningMessage("Eski şifrenizi yanlış girdiniz!");
                    }
                }
                else
                {
                    this.WarningMessage("Yeni şifreniz eşleşmiyor!");
                }
            }
            catch (Exception e)
            {
                this.ErrorMessage($"Bir hata oluştu! ({e.Message})");
            }

            return View(model);
        }
    }
}