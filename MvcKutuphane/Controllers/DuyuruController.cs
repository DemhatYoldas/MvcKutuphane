using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        // GET: Duyuru
        public ActionResult Index()
        {
            var degerler = db.TBLDUYURULAR.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DuyuruEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DuyuruEkle(TBLDUYURULAR a)
        {
            a.Durum = true;
            db.TBLDUYURULAR.Add(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruGetir(int id)
        {
            var Duyuru = db.TBLDUYURULAR.Find(id);
            return View("DuyuruGetir", Duyuru);
        }

        [HttpPost]
        public ActionResult DuyuruGuncelle(TBLDUYURULAR p)
        {
            var ktg = db.TBLDUYURULAR.Find(p.ID);
            ktg.KATEGORI = p.KATEGORI;
            ktg.ICERIK = p.KATEGORI;
            ktg.Durum = p.Durum;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DuyuruSil(int id)
        {
            var Duyuru = db.TBLDUYURULAR.Find(id);
            Duyuru.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}