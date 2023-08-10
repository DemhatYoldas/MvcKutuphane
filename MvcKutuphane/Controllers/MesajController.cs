using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class MesajController : Controller
    {
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();
        // GET: Mesaj
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.ALICI == uyemail.ToString()).ToList();
            return View(mesajlar);
        }

        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBLMESAJLAR.Where(x => x.GONDEREN == uyemail.ToString()).ToList();
            return View(mesajlar);
        }

        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJLAR t)
        {
            var uyemail = (string)Session["Mail"].ToString();
            t.GONDEREN = uyemail.ToString();
            t.TARIH = DateTime.Now;
            t.DURUM = true;
            db.TBLMESAJLAR.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult MesajGuncelle(TBLMESAJLAR p)
        {
            try
            {
                var msj = db.TBLMESAJLAR.Find(p.ID);
                if (msj != null)
                {
                    msj.GONDEREN = p.GONDEREN;
                    msj.KONU = p.KONU;
                    msj.TARIH = p.TARIH;
                    msj.ICERIK = p.ICERIK;
                    msj.DURUM = false;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Hata mesajını ekrana veya log dosyasına yazdırabilirsiniz.
                // Örnek olarak:
               ViewBag.ErrorMessage = ex.Message;
                // veya
                // Log.Error(ex, "Güncelleme sırasında hata oluştu.");
                return View("Index"); // Hata sayfasına yönlendirme yapabilirsiniz.
            }
        }


    }
}