using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            var uyesayi = db.TBLUYELER.Count();
            var kitapsayi = db.TBLKITAP.Count();
            var Odunckitap = db.TBLKITAP.Where(x=>x.DURUM==false).Count();
            var Kasa = db.TBLCEZALAR.Sum(x=>x.PARA);
            ViewBag.Dgruye = uyesayi;
            ViewBag.Dgrkitap = kitapsayi;
            ViewBag.Dgrodunc = Odunckitap;
            ViewBag.Dgrkasa = Kasa;
            return View();
        }
        public ActionResult VisualizeUrunResult()
        {
            return Json(liste());
        }
        public List<Class> liste()
        {
            List<Class> cs = new List<Class>();
            cs.Add(new Class()
            {
                yayinevi = "Mars",
                sayi = 4
            });
            cs.Add(new Class()
            {
                yayinevi = "demo",
                sayi = 8
            });
            cs.Add(new Class()
            {
                yayinevi = "komagene",
                sayi = 5
            });
            return cs;
        }
    }
}