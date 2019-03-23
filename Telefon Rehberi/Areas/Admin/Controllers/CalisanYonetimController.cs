using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rehber.Bl.Interface;
using Rehber.Model.DataModel;
using Telefon_Rehberi.Areas.Admin.Models.CalisanYonetim;
using Telefon_Rehberi.Helpers;

namespace Telefon_Rehberi.Areas.Admin.Controllers
{
    [UserAuthorize]
    public class CalisanYonetimController : Controller
    {
        private ICalisanYonetimi _calisanYonetimi;
        private IDepartmanYonetimi _departmanYonetimi;

        public CalisanYonetimController(ICalisanYonetimi calisanYonetimi, IDepartmanYonetimi departmanYonetimi)
        {
            _calisanYonetimi = calisanYonetimi;
            _departmanYonetimi = departmanYonetimi;
        }

        // GET: Admin/CalisanYonetim
        public ActionResult CalisanDuzenle(int? id)
        {
            CalisanDuzenleViewModel model = new CalisanDuzenleViewModel();

            if (id != null)
            {
                model.Calisan = _calisanYonetimi.Get(c => c.ID == id);
                model.CalisanList = _calisanYonetimi.GetAll(c => c.ID != id).ToList();
            }
            else
            {
                model.CalisanList = _calisanYonetimi.GetAll().ToList();
            }

            var calisanlar = model.CalisanList.Select(c => new
            {
                Text = c.Ad + " " + c.Soyad,
                Value = c.ID
            }).ToList();
            model.CalisanSelectList = new SelectList(calisanlar, "Value", "Text");

            model.DepartmanList = _departmanYonetimi.GetAll().OrderBy(d => d.Ad).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult CalisanDuzenle(CalisanDuzenleViewModel model)
        {
            try
            {
                _calisanYonetimi.AddOrUpdate(model.Calisan);

                this.SuccessMessage($"<strong>{model.Calisan.Ad + " " + model.Calisan.Soyad}</strong> isimli çalışan başarıyla kaydedildi!");
            }
            catch (Exception e)
            {
                this.ErrorMessage($"Çalışan kaydedilirken bir hata ile karşılaşıldı! <strong>({e.Message})</strong>");
            }

            return RedirectToAction("Index", "UI");
        }

        public ActionResult CalisanSil(int id)
        {
            var calisanSayisi = _calisanYonetimi.Get(d => d.ID == id).tblCalisan1.Count;
            if (calisanSayisi > 0)
            {
                this.ErrorMessage($"Bu çalışanın altında <strong>{calisanSayisi}</strong> çalışan bulunmaktadır.");
            }
            else
            {
                _calisanYonetimi.Delete(id);

                this.WarningMessage("Çalışan Silindi!");
            }

            return RedirectToAction("Index","UI");
        }

        public string CalisanAdGetir(int id)
        {
            var calisan = _calisanYonetimi.Get(c => c.ID == id);

            return (calisan.Ad + " " + calisan.Soyad).ToUpper();
        }
    }
}