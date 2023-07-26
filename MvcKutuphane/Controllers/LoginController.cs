using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    }
}