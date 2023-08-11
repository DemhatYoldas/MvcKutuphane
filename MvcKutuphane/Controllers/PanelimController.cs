using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class PanelimController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();

        // GET: Panelim
        [HttpGet]
        [Authorize]
        public ActionResult Anasayfa()
        {
            return View();
        }

        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBLUYELER.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }

        [HttpPost]
        public ActionResult Index2(TBLUYELER p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBLUYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.AD = p.AD;
            uye.SOYADI = p.SOYADI;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.TELEFON = p.TELEFON;
            uye.OKUL = p.OKUL;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}