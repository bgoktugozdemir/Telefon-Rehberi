using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rehber.Bl.Interface;
using Telefon_Rehberi.Areas.Admin.Models.DepartmanYonetim;

namespace Telefon_Rehberi.Areas.Admin.Controllers
{
    public class DepartmanYonetimController : Controller
    {
        private IDepartmanYonetimi _departmanYonetimi;

        public DepartmanYonetimController(IDepartmanYonetimi departmanYonetimi)
        {
            _departmanYonetimi = departmanYonetimi;
        }

        // GET: Admin/DepartmanYonetim
        public ActionResult DepartmanDuzenle(int? id)
        {
            DepartmanDuzenleViewModel model = new DepartmanDuzenleViewModel();

            if (id != null)
            {
                model.Departman = _departmanYonetimi.Get(d => d.ID == id);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult DepartmanDuzenle(DepartmanDuzenleViewModel model)
        {
            try
            {
                _departmanYonetimi.AddOrUpdate(model.Departman);

                this.SuccessMessage($"<strong>{model.Departman.Ad}</strong> departmanı başarıyla kaydedildi.");
            }
            catch (Exception e)
            {
                this.ErrorMessage($"Departman kaydedilirken bir hata ile karşılaşıldı! <strong>({e.Message})</strong>");
            }



            return RedirectToAction("Index", "UI");
        }

        public ActionResult DepartmanSil(int id)
        {
            var calisanSayisi = _departmanYonetimi.Get(d => d.ID == id).tblCalisan.Count;
            if (calisanSayisi > 0)
            {
                this.ErrorMessage($"Bu departmana kayıtlı <strong>{calisanSayisi}</strong> çalışan bulunmaktadır.");
            }
            else
            {
                _departmanYonetimi.Delete(id);

                this.WarningMessage("Departman Silindi!");
            }

            return RedirectToAction("Index", "UI");
        }
    }
}