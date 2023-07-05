using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKutuphane.Controllers
{
    public class CikisController : Controller
    {
        // GET: Cikis
        public ActionResult Index()
        {
            return View();
        }
    }
}