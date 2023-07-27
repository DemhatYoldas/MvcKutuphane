using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
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
                Session["id"] = bilgiler.ID.ToString();
                Session["Resim"] = bilgiler.FOTOGRAF.ToString();
                Session["Ad"] = bilgiler.AD.ToString();
                Session["Soyad"] = bilgiler.SOYADI.ToString();
                Session["Mail"] = bilgiler.MAIL.ToString();
                Session["Kullaniciad"] = bilgiler.KULLANICIADI.ToString();
                Session["Şifre"] = bilgiler.SIFRE.ToString();
                Session["Okuladi"] = bilgiler.OKUL.ToString();
                return RedirectToAction("Index","Panelim");

            }
            else
            {
                return View();
            }
        }
    }
}