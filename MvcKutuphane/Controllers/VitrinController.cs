using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
using MvcKutuphane.Models.Siniflarim;

namespace MvcKutuphane.Controllers
{
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DBKUTUPHANEEntities db=new DBKUTUPHANEEntities();
        public ActionResult Index()
        {
            Class1 cs =new Class1();
            cs.Deger1 = db.TBLKITAP.ToList();
            cs.Deger2=db.TBLHAKKIMIZDA.ToList();
            //var degerler=db.TBLKITAP.ToList();
            return View(cs);
        }
    }
}