using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using PagedList.Mvc;
using PagedList;

namespace MvcKutuphane.Controllers
{
    [Authorize(Roles = "A")]
    public class UyeController : Controller
    {
        // GET: Uye
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBLUYELER.ToList().ToPagedList(sayfa,3);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER p) 
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            else
            {
                db.TBLUYELER.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult UyeSil(int id )
        {
            var uye = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UyeGetir(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            return View("UyeGetir", uye);
        }

        public ActionResult UyeGuncelle(TBLUYELER p)
        {
            var uye = db.TBLUYELER.Find(p.ID);
            uye.AD=p.AD;
            uye.SOYADI=p.SOYADI;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE=p.SIFRE;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.TELEFON = p.TELEFON;
            uye.OKUL=p.OKUL;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Uyekitapgecmis(int id)
        {
            var kitap = db.TBLHAREKET.Where(z=>z.UYE==id).ToList();
            var uyekit = db.TBLUYELER.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYADI).FirstOrDefault();
            ViewBag.u1 = uyekit;
            return View(kitap);
        }


    }
}