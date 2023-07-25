using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class istatistikController : Controller
    {
        // GET: istatistik
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

    }
}