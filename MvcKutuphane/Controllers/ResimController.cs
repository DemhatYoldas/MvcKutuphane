using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class ResimController : Controller
    {
        // GET: Resim
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Resimyukle(HttpPostedFileBase dosya)
        {
            if (dosya != null && dosya.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/Galeri/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Index");
        }

    }
}