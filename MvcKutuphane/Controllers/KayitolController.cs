using MvcKutuphane.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class KayitolController : Controller
    {
        // GET: Kayitol
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(TBLUYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            var varsayilan = "/Images/Bos/white.jpg";
            p.FOTOGRAF = varsayilan;
            db.TBLUYELER.Add(p);
            db.SaveChanges();
            return RedirectToAction("Girisyap", "Login");
        }
    }
}