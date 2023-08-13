using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();
        public ActionResult Girisyap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Girisyap(TBLUYELER p)
        {
            var bilgiler = db.TBLUYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                //TempData["id"] = bilgiler.ID.ToString();
                //TempData["Resim"] = bilgiler.FOTOGRAF.ToString();
                //TempData["Ad"] = bilgiler.AD.ToString();
                //TempData["Soyad"] = bilgiler.SOYADI.ToString();
                //TempData["Kullaniciad"] = bilgiler.KULLANICIADI.ToString();
                //TempData["Sifre"] = bilgiler.SIFRE.ToString();
                //TempData["Okuladi"] = bilgiler.OKUL.ToString();
                return RedirectToAction("Anasayfa","Panelim");

            }
            else
            {
                return View();
            }
        }
    }
}