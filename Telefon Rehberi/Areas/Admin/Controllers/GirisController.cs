using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using Rehber.Bl.Interface;
using Telefon_Rehberi.Areas.Admin.Models.Giris;
using Telefon_Rehberi.Helpers.Giris;

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
        public ActionResult Index(GirisViewModel model)
        {
            if (model.Pass == _ayarlarYonetimi.Get(a => a.Anahtar == "AdminPass").Deger)
            {
                return RedirectToAction("Index", "UI");
            }
            else
            {
                CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel
                {
                    Pass = _ayarlarYonetimi.Get(a => a.Anahtar == "AdminPass").Deger
                };

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                string userData = serializer.Serialize(serializeModel);

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, model.Pass, DateTime.Now, DateTime.Now.AddMinutes(120), false, userData);

                string encTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                Response.Cookies.Add(faCookie);

                //FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);

                return RedirectToAction("Index", "Home");
            }

            this.ErrorMessage("Şifre yanlış!");
            return RedirectToAction("Index");
        }
    }
}